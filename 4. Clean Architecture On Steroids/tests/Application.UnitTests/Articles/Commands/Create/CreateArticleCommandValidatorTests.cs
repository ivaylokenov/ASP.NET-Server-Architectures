namespace Blog.Application.UnitTests.Articles.Commands.Create
{
    using Application.Articles.Commands.Create;
    using Shouldly;
    using Xunit;

    public class CreateArticleCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValidShouldBeTrueWhenTitleIsNotNull()
        {
            var command = new CreateArticleCommand
            {
                Title = "Test Title",
                Content = "Test Content"
            };

            var validator = new CreateArticleCommandValidator();

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValidShouldBeFalseWhenTitleIsMoreThanFortySymbols()
        {
            var command = new CreateArticleCommand
            {
                Title = new string('A', 50),
                Content = "Test Content"
            };

            var validator = new CreateArticleCommandValidator();

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
