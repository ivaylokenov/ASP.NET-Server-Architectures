namespace Blog.Web.IntegrationTests.Pipeline
{
    using System.Linq;
    using Application.Articles.Commands.ChangeVisibility;
    using Infrastructure.Persistence;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Web.Features;
    using Xunit;

    public class ArticlesPipelineTests
    {
        [Theory]
        [InlineData(1)]
        public void ChangeVisibilityShouldBeRoutedCorrectlyAndShouldReturnNoContent(int id)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Put)
                    .WithLocation("api/Articles/ChangeVisibility")
                    .WithJsonBody(new {Id = id}))
                .To<ArticlesController>(c => c
                    .ChangeVisibility(new ChangeArticleVisibilityCommand {Id = id}))
                .Which(controller => controller
                    .WithData(data => data
                        .WithEntities<BlogDbContext>(TestData.Articles)))
                .ShouldHave()
                .Data(data => data
                    .WithEntities<BlogDbContext>(entities => entities
                        .Articles
                        .FirstOrDefault(a =>
                            a.Id == id && a.IsPublic)
                        .ShouldNotBeNull()))
                .AndAlso()
                .ShouldReturn()
                .NoContent();
    }
}
