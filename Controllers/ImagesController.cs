using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using Mi_Granjita_Paraiso.Entities;
using Mi_Granjita_Paraiso.Helpers;
using Mi_Granjita_Paraiso.DTOs;

namespace Mi_Granjita_Paraiso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#if !DEBUG
    [Authorize]
#else
    [AllowAnonymous]
#endif
    public class ImagesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration appConfig;

        public ImagesController(AppDbContext context, IMapper mapper, IConfiguration appConfig)
        {
            this.context = context;
            this.mapper = mapper;
            this.appConfig = appConfig;
        }

        [HttpPost]
        public async Task<ActionResult> UpLoadImageAsync(IFormFile file)
        {
            string path, fileName;
            Entities.File newFile;

            if(file == null)
            {
                return BadRequest(new
                {
                    Message = "Please add a File before send the request"
                });
            }

            try
            {
                UserSession session = new(User);

                path = appConfig.GetValue<string>(WebHostDefaults.ContentRootKey) + @$"\wwwroot\{session.Id}\images\temp\";
                fileName = Path.GetRandomFileName();
                string physicalPath = Path.Combine(path);

                //Se revisa que exista el directorio, caso contrario se genera
                if (!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                }
                
                string fileExtension = file.FileName.Split('.').Last();

                fileName = $"{ fileName }.{ fileExtension }";


                using (var stream = System.IO.File.Create(physicalPath + fileName))
                {
                    await file.CopyToAsync(stream);
                }

                newFile = new Entities.File
                {
                    CategoryId = 1,
                    DateSaved = DateTime.Now,
                    Path = $"{ path }{ fileName}",
                    SavedByUserId = session.Id,
                    Name = file.Name.Split('\\').Last().Split('.').First()
                };

                await context.Files.AddAsync(newFile);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, title: "Error trying to save file by error:");
            }

            return Created(newFile.Path, mapper.Map<FileCreatedDTO>(newFile));
        }
    }
}
