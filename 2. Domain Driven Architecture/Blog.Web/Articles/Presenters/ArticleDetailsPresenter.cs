namespace Blog.Web.Articles.Presenters
{
    using Application.Articles.Models;
    using Application.Ports;
    using Microsoft.AspNetCore.Mvc;

    public class ArticleDetailsPresenter : IOutputPort<ArticleDetailsOutputModel>
    {
        public IActionResult Result { get; private set; }

        public void Success(ArticleDetailsOutputModel output)
            => this.Result = new OkObjectResult(output);

        public void Error(string message = null)
            => this.Result = new NotFoundObjectResult(message);
    }
}
