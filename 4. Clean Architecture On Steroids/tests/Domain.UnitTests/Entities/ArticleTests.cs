namespace Blog.Domain.UnitTests.Entities
{
    using Domain.Entities;
    using Exceptions;
    using Xunit;

    public class ArticleTests
    {
        [Fact]
        public void TitleShouldThrowExceptionWhenNull()
        {
            // Assert
            Assert.Throws<InvalidArticleException>(
                () => new Article(null, "Test Content", "Test Id"));
        }

        [Fact]
        public void UserIdShouldThrowExceptionWhenNull()
        {
            // Assert
            Assert.Throws<InvalidEntityException>(
                () => new Article("Test Title", "Test Content", null));
        }
    }
}
