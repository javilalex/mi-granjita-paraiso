using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Mi_Granjita_Paraiso.DTOs;
using Mi_Granjita_Paraiso.Entities;
using Mi_Granjita_Paraiso.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Mi_Granjita_Paraiso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;
        private readonly IConfiguration appConfig;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AppDbContext context;

        public AccountController(AppDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IMapper mapper, IConfiguration config)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.appConfig = config;
        }
        /// <summary>
        /// Accion que permite registrar un usuario en la plataforma
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp([FromBody] CreateUser data)
        {
            //Se revisa que no este registrado el correo
            if (await context.Users.AnyAsync(x => x.Email == data.Email))
            {
                return BadRequest($"El correo {data.Email} ya se encuentra registrado");
            }

            if (await context.Users.AnyAsync(x => x.UserName == data.UserName))
            {
                return BadRequest($"El usuario {data.UserName} ya se encuentra registrado");
            }

            //Se revisa que la contraseña este confirmada
            if (data.Password != data.PasswordConfirm)
            {
                return BadRequest("La confirmacion de la contraseña no coincide");
            }

            IdentityUser identityUser = mapper.Map<IdentityUser>(data);

            var userRegistered = await userManager.CreateAsync(identityUser, data.Password);

            if (userRegistered.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(userRegistered.Errors);
            }
        }
        /// <summary>
        /// Accion que permite autenticar un usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("Auth")]
        public async Task<ActionResult> Auth([FromBody] UserAuth data)
        {
            var user = await userManager.FindByEmailAsync(data.UserName);

            if (user == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            var result = await signInManager.PasswordSignInAsync(user, data.Password, data.RememberMe, true);

            if (!result.Succeeded)
            {
                return NotFound();
            }

            var timeToExpire = DateTime.Now.AddMinutes(Double.Parse(appConfig["Jwt:TimeToExpire"]));

            var token = JWTHelper.CreateUserToken(appConfig["Jwt:Key"], appConfig["Jwt:Issuer"], appConfig["Jwt:Audience"], timeToExpire, user);

            return Ok(new
            {
                token,
                expiration = timeToExpire
            });
        }
        /// <summary>
        /// Metodo Generado para cambiar la contraseña del usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePassword  data)
        {
            UserSession session = new(User);

            if(data.Password != data.PasswordConfirm)
            {
                return BadRequest(new
                {
                    Message = "Passwords does not match"
                });
            }

            var user = await userManager.FindByIdAsync(session.Id);

            if(user == null)
            {
                return NotFound(new
                {
                    Message = "User not found"
                });
            }

            if (! await userManager.CheckPasswordAsync(user, data.OldPassword))
            {
                return BadRequest(new
                {
                    Message = "Invalid Password"
                });
            }

            await userManager.ChangePasswordAsync(user, data.OldPassword, data.Password);

            return Ok();
        }
    }
}
