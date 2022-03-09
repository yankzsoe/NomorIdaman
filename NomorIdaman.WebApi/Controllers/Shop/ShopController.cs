using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NomorIdaman.Application.Common.Models.Responses;
using NomorIdaman.Application.Features.Shop.Queries.GetList;

namespace NomorIdaman.WebApi.Controllers.ProviderCard {
    [ApiExplorerSettings(GroupName = "Shop")]
    [Route("api/shop")]
    public class ShopController : ApiControllerBase {

        /// <summary>
        /// Get list of Shops
        /// </summary>
        [HttpGet("")]
        public async Task<ActionResult<PagedResponse<ShopGetListViewModel>>> GetList([FromQuery] ShopGetListQuery query) {
            return Ok(await Mediator.Send(query));
        }
    }
}
