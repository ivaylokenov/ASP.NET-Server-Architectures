namespace Blog.Web.Features
{
    using System.Threading.Tasks;
    using Application.Articles.Commands.ChangeVisibility;
    using Application.Articles.Commands.Create;
    using Application.Articles.Queries.Details;
    using Application.Articles.Queries.IsByUser;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ArticlesController : ApiController
    {
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDetailsOutputModel>> Details(
            [FromRoute] ArticleDetailsQuery query)
            => await this.Mediator.Send(query);

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateArticleCommand command)
            => await this.Mediator.Send(command);

        [HttpPut("[action]")]
        public async Task<ActionResult> ChangeVisibility(ChangeArticleVisibilityCommand command)
        {
            await this.Mediator.Send(command);

            return this.NoContent();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<bool>> IsByUser(
            [FromRoute] ArticleIsByUserQuery query)
            => await this.Mediator.Send(query);
    }
}
