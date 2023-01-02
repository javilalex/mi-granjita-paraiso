using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper;
using Mi_Granjita_Paraiso.DTOs;
using Mi_Granjita_Paraiso.Entities;
using Mi_Granjita_Paraiso.Utilities;

using static Mi_Granjita_Paraiso.Utilities.PredicateBuilder;
using Mi_Granjita_Paraiso.Interfaces;
using Mi_Granjita_Paraiso.DTOs.Item;
using Mi_Granjita_Paraiso.Enums;

namespace Mi_Granjita_Paraiso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration config;

        public StoreController(AppDbContext context, IMapper mapper, IConfiguration config)
        {
            this.context = context;
            this.mapper = mapper;
            this.config = config;
        }
        /// <summary>
        /// Obtiene los elementos que estan disponibles para el marketplace
        /// </summary>
        /// <param name="data">Los filtros a usar para delimitar la informacion</param>
        /// <param name="cancellation">Token para cancelar la peticion, no es necesario mandarlo</param>
        /// <param name="modelType">Tipo de modelo que se regresara</param>
        /// <returns>
        /// Los elementos que coincidan con el filtro seleccionado, en caso de que no se especifique se entregaran los ultimos elementos registrados
        /// delimitados por <see cref="MarketPlaceSearch.Take"/> y omitidos por <see cref="MarketPlaceSearch.Skip"/>
        /// </returns>
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<IItem>>> Search([FromBody] MarketPlaceSearch data, CancellationToken cancellation, ModelTypes modelType = ModelTypes.Standard)
        {
            Expression<Func<Item, IItem>> getItem = null;

            List<Expression<Func<Item, bool>>> expressionList = new()
            {
                x => x.PublishDate < DateTime.Now
            };

            if (data.StartDate.HasValue) expressionList.Add(x => x.PublishDate >= data.StartDate);
            if (data.EndDate.HasValue)
            {
                DateTime endDate = data.EndDate.Value.AddDays(1);
                expressionList.Add(x => x.PublishDate <= endDate);
            }
            if (data.CategoriesId != null) expressionList.Add(x => data.CategoriesId.Contains(x.CategoryId));
            if (data.Ids != null) expressionList.Add(x => data.Ids.Contains(x.Id));

            var filter = expressionList.Aggregate((acc, current) => acc.And(current));

            var query = context.Items.Where(filter)
                                     .Take(data.Take)
                                     .Skip(data.Skip)
                                     .Include(x => x.Status)
                                     .Include(x => x.Category)
                                     .Include(x => x.ItemFiles);

            IEnumerable<IItem> items = null;

            switch (modelType)
            {
                case ModelTypes.Lite:
                    items = mapper.Map<List<ItemDTOStandard>>(await query.ToListAsync(cancellation));
                    break;
                default:
                case ModelTypes.Standard:
                    break;
                case ModelTypes.Full:
                    break;
            }


            return Ok(items);
        }
        [HttpPost]
        public async Task<ActionResult<ItemDTOStandard>> Post([FromBody] ItemDTOStandard data)
        {
            Item item = mapper.Map<Item>(data);
            item.SavedUserId = "2bf4545d-f478-4abd-8e5a-593bf6bc0e28";
            await context.Items.AddAsync(item);

            await context.SaveChangesAsync();

            return mapper.Map<ItemDTOStandard>(item);
        }
        [HttpPost("{id:long}/AddFile/{fileId:int}")]
        public async Task<ActionResult> AddFile(long id, int fileId)
        {
            if(!context.Items.Any(x => x.Id == id)) return NotFound("Item not found");
            if (!context.ItemFiles.Any(x => x.Id == fileId)) return NotFound("File not found");

            await context.ItemFiles.AddAsync(new ItemFile
            {
                Id = id,
                FileId = fileId
            });

            await context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IItem>> Get([FromRoute] long id, CancellationToken cancellation)
        {

            var result = await Search(new MarketPlaceSearch
            {
                Ids = new long[] { id }
            }, cancellation);

            var item = result.Value.FirstOrDefault();

            if(item != null) {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromRoute] long id, CancellationToken cancellation)
        {
            if (await context.Items.AnyAsync(x => x.Id == id, cancellation)) return NotFound("El elemento seleccion ya ha sido borrado anteriormente");

            context.Items.Remove(new Item
            {
                Id = id,
            });

            await context.SaveChangesAsync(cancellation);

            return Ok("Elemento removido");
        }

        [HttpPatch]
        public async Task<ActionResult<Entities.Item>> Patch([FromRoute] long id, [FromBody] JsonPatchDocument<Entities.Item> data, CancellationToken cancellation)
        {
            var element = await context.Items.FirstAsync(x => x.Id == id && x.StatusId != 3, cancellation);

            if (element == null) return NotFound();

            data.ApplyTo(element);

            await context.SaveChangesAsync(cancellation);

            return Ok(element);
        }

        [HttpPut]
        public async Task<ActionResult<Item>> Put([FromRoute] long id, [FromBody] Entities.Item data, CancellationToken cancellation)
        {
            var element = await context.Items.FirstAsync(x => x.Id == id && x.StatusId != 3, cancellation);

            if (element == null) return NotFound();

            await context.SaveChangesAsync(cancellation);

            return Ok(element);
        }
    }
}
