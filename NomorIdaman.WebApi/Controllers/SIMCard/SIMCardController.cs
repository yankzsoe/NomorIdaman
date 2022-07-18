using Microsoft.AspNetCore.Mvc;
using NomorIdaman.Application.Common.Models.Responses;
using NomorIdaman.Application.Features.SIMCard.Queries.GetList;
using NomorIdaman.Application.Features.SIMCard.Queries.GetListSummary;
using NomorIdaman.Application.Features.SIMCard.Queries.GetListUnion;

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

        /// <summary>
        /// Get list of SIM Cards
        /// </summary>
        [HttpGet("union")]
        public async Task<ActionResult<PagedResponse<SIMCardGetListUnionViewModel>>> GetListUnion([FromQuery] SIMCardGetListUnionQuery query) {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Summary of SIM Card
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<Response<List<SIMCardGetListSummaryViewModel>>>> GetListSummary([FromQuery] SIMCardGetListSummaryQuery query) {
            return Ok(await Mediator.Send(query));
        }
    }
}
