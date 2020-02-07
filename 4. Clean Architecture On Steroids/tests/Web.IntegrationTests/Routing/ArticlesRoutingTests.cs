namespace Blog.Web.IntegrationTests.Routing
{
    using Application.Articles.Commands.ChangeVisibility;
    using Application.Articles.Commands.Create;
    using Application.Articles.Queries.Details;
    using MyTested.AspNetCore.Mvc;
    using Web.Features;
    using Xunit;

    public class ArticlesRoutingTests
    {
        [Fact]
        public void DetailsShouldBeRoutedCorrectly()
            => MyRouting
                .Configuration()
                .ShouldMap("api/Articles/1")
                .To<ArticlesController>(c => c.Details(new ArticleDetailsQuery { Id = 1 }));

        [Theory]
        [InlineData("Test Title", "Test Content")]
        public void CreateShouldBeRoutedCorrectly(string title, string content)
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Post)
                    .WithLocation("api/Articles")
                    .WithJsonBody(new
                    {
                        Title = title,
                        Content = content
                    }))
                .To<ArticlesController>(c => c.Create(new CreateArticleCommand
                {
                    Title = title,
                    Content = content
                }));

        [Theory]
        [InlineData(1)]
        public void ChangeVisibilityShouldBeRoutedCorrectly(int id)
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Put)
                    .WithLocation("api/Articles/ChangeVisibility")
                    .WithJsonBody(new { Id = id }))
                .To<ArticlesController>(c => c.ChangeVisibility(new ChangeArticleVisibilityCommand
                {
                    Id = id
                }));
    }
}
