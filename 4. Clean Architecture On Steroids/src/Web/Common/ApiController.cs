namespace Blog.Web.Common
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator 
            => this.mediator ??= this.HttpContext
                .RequestServices
                .GetService<IMediator>();
    }
}
