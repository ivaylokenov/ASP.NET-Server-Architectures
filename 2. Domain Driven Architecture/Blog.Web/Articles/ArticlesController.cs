namespace Blog.Web.Articles
{
    using System.Threading.Tasks;
    using Application.Articles.Handlers;
    using Microsoft.AspNetCore.Mvc;
    using Presenters;

    public class ArticlesController : ControllerBase
    {
        private readonly IArticleDetailsInputPort articleDetailsInputPort;
        private readonly ArticleDetailsPresenter articleDetailsPresenter;

        public ArticlesController(
            IArticleDetailsInputPort articleDetailsInputPort,
            ArticleDetailsPresenter articleDetailsPresenter)
        {
            this.articleDetailsInputPort = articleDetailsInputPort;
            this.articleDetailsPresenter = articleDetailsPresenter;
        }

        public async Task<IActionResult> Details(int id)
        {
            await this.articleDetailsInputPort.Handle(id, this.articleDetailsPresenter);
            return this.articleDetailsPresenter.Result;
        }
    }
}
