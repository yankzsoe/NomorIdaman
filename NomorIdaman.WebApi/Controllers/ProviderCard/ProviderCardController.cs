using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NomorIdaman.Application.Common.Models.Responses;
using NomorIdaman.Application.Features.ProviderCard.Queries.GetList;

namespace NomorIdaman.WebApi.Controllers.ProviderCard {
    [ApiExplorerSettings(GroupName = "ProviderCard")]
    [Route("api/provider-card")]
    public class ProviderCardController : ApiControllerBase {

        /// <summary>
        /// Get list of Provider Cards
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ActionResult<PagedResponse<ProviderGetListViewModel>>> GetList([FromQuery] ProviderGetListQuery query) {
            return Ok(await Mediator.Send(query));
        }
    }
}
