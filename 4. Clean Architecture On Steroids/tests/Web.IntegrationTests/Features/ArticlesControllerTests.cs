namespace Blog.Web.IntegrationTests.Features
{
    using System.Linq;
    using Application.Articles.Commands.Create;
    using Application.Articles.Queries.Details;
    using Blog.Web.Features;
    using Infrastructure.Persistence;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class ArticlesControllerTests
    {
        [Fact]
        public void ArticleControllerShouldBeForAuthorizedUsers()
            => MyController<ArticlesController>
                .ShouldHave()
                .Attributes(attr => attr
                    .RestrictingForAuthorizedRequests());

        [Fact]
        public void DetailsShouldBeAllowedForAnonymousUsersAndGetRequestsOnly()
            => MyController<ArticlesController>
                .Calling(c => c.Details(With.Default<ArticleDetailsQuery>()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .AllowingAnonymousRequests()
                    .RestrictingForHttpMethod(HttpMethod.Get));

        [Theory]
        [InlineData(1)]
        public void DetailsShouldReturnCorrectArticleDetailsOutputModelWithValidData(int id)
            => MyController<ArticlesController>
                .Instance(controller => controller
                    .WithData(entities => entities
                        .WithEntities<BlogDbContext>(TestData.Articles)))
                .Calling(c => c.Details(new ArticleDetailsQuery { Id = id }))
                .ShouldReturn()
                .ActionResult<ArticleDetailsOutputModel>(result => result
                    .Passing(model => model.Id == id && model.Author == TestUser.Username));

        [Theory]
        [InlineData("Test Title", "Test Content")]
        public void CreateShouldSaveArticleToTheDatabaseAndReturnCorrectArticleId(string title, string content)
            => MyController<ArticlesController>
                .Instance(controller => controller
                    .WithData(entities => entities
                        .WithEntities<BlogDbContext>(TestData.Articles)))
                .Calling(c => c.Create(new CreateArticleCommand
                {
                    Title = title,
                    Content = content
                }))
                .ShouldHave()
                .Data(data => data
                    .WithEntities<BlogDbContext>(entities =>
                    {
                        entities.Articles.Count().ShouldBe(3);

                        entities
                            .Articles
                            .FirstOrDefault(a => 
                                a.Title == title && 
                                a.Content == content &&
                                a.CreatedBy == TestUser.Identifier &&
                                a.CreatedOn == TestData.TestNow)
                            .ShouldNotBeNull();
                    }))
                .AndAlso()
                .ShouldReturn()
                .ActionResult<int>(result => result
                    .Passing(model => model != 0));
    }
}
