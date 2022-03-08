using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NomorIdaman.WebApi.Controllers {
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public abstract class ApiControllerBase : ControllerBase {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
