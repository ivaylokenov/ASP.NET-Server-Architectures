namespace Blog.Application.Articles.Handlers
{
    using System.Threading.Tasks;
    using Infrastructure;
    using Models;
    using Ports;

    public class ArticleDetailsHandler : IArticleDetailsInputPort
    {
        private readonly IArticleGateway articleGateway;
        private readonly IUserService userProvider;
        private readonly ILogger<ArticleDetailsHandler> logger;

        public ArticleDetailsHandler(
            IArticleGateway articleGateway, 
            IUserService userProvider,
            ILogger<ArticleDetailsHandler> logger)
        {
            this.articleGateway = articleGateway;
            this.userProvider = userProvider;
            this.logger = logger;
        }

        public async Task Handle(int input, IOutputPort<ArticleDetailsOutputModel> output)
        {
            var article = await this.articleGateway.Details(input);
            if (article == null)
            {
                this.logger.LogInformation($"Article {input} could not be found.");
                output.Error();
                return;
            }

            var author = this.userProvider.GetUserName(article.UserId);

            output.Success(new ArticleDetailsOutputModel(
                article.Id, 
                article.Title,
                article.Content, 
                article.IsPublic,
                article.PublishedOn,
                author));
        }
    }
}
