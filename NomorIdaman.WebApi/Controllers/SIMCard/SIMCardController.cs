using Microsoft.AspNetCore.Mvc;
using NomorIdaman.Application.Common.Models.Responses;
using NomorIdaman.Application.Features.SIMCard.Queries.GetList;

namespace NomorIdaman.WebApi.Controllers.SIMCard {
    [ApiExplorerSettings(GroupName = "SIMCard")]
    [Route("api/sim-card")]
    public class ShopController : ApiControllerBase {

        /// <summary>
        /// Get list of SIM Cards
        /// </summary>
        [HttpGet("")]
        public async Task<ActionResult<PagedResponse<SIMCardGetListViewModel>>> GetList([FromQuery] SIMCardGetListQuery query) {
            return Ok(await Mediator.Send(query));
        }
    }
}
