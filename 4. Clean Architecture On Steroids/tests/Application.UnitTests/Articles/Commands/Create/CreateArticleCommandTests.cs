namespace Blog.Application.UnitTests.Articles.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Articles.Commands.Create;
    using Shouldly;
    using Xunit;

    public class CreateArticleCommandTests : CommandTestBase
    {
        [Fact]
        public async Task HandleShouldPersistArticle()
        {
            var command = new CreateArticleCommand
            {
                Title = "Test Title Command",
                Content = "Test Content Command"
            };

            var handler = new CreateArticleCommand
                .CreateArticleCommandHandler(this.Context, this.CurrentUser);

            var result = await handler.Handle(command, CancellationToken.None);

            var article = this.Context.Articles.Find(result);

            article.ShouldNotBeNull();
            article.Title.ShouldBe(command.Title);
            article.CreatedBy.ShouldBe(TestUserId);
        }
    }
}
