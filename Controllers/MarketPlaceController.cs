using AutoMapper;
using Mi_Granjita_Paraiso.DTOs;
using Mi_Granjita_Paraiso.Entities;
using Mi_Granjita_Paraiso.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

using static Mi_Granjita_Paraiso.Utilities.PredicateBuilder;

namespace Mi_Granjita_Paraiso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketPlaceController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration config;

        public MarketPlaceController(AppDbContext context, IMapper mapper, IConfiguration config)
        {
            this.context = context;
            this.mapper = mapper;
            this.config = config;
        }
        /// <summary>
        /// Obtiene los elementos que estan disponibles para el marketplace
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetItems(MarketPlaceSearch data)
        {

            List<Expression<Func<Item, bool>>> expressionList = new()
            {
                x => x.PublishDate > DateTime.Now
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

            var result = context.Items.Where(filter)
                                      .Take(data.Take)
                                      .Skip(data.Skip);

            return null;
        }
    }
}
