namespace Blog.Application.Articles.Commands.ChangeVisibility
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using MediatR;

    public class ChangeArticleVisibilityCommand : IRequest
    {
        public int Id { get; set; }

        public class ChangeArticleVisibilityCommandHandler : AsyncRequestHandler<ChangeArticleVisibilityCommand>
        {
            private readonly IBlogData data;
            private readonly IDateTime dateTime;

            public ChangeArticleVisibilityCommandHandler(
                IBlogData data, 
                IDateTime dateTime)
            {
                this.data = data;
                this.dateTime = dateTime;
            }

            protected override async Task Handle(
                ChangeArticleVisibilityCommand request, 
                CancellationToken cancellationToken)
            {
                var article = await this.data.Articles.FindAsync(request.Id);

                if (article == null)
                {
                    return;
                }

                article.IsPublic = !article.IsPublic;

                if (article.PublishedOn == null)
                {
                    article.PublishedOn = this.dateTime.Now;
                }

                await this.data.SaveChanges(cancellationToken);
            }
        }
    }
}
