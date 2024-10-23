using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartMaint.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
