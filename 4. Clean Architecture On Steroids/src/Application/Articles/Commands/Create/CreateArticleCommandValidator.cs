namespace Blog.Application.Articles.Commands.Create
{
    using FluentValidation;

    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            this.RuleFor(a => a.Title)
                .MaximumLength(40)
                .NotEmpty();

            this.RuleFor(a => a.Content)
                .NotEmpty();
        }
    }
}
