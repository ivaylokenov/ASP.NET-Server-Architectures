namespace Blog.Application.Articles.Queries.Details
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ArticleDetailsQuery : IRequest<ArticleDetailsOutputModel>
    {
        public int Id { get; set; }

        public class ArticleDetailsQueryHandler : IRequestHandler<ArticleDetailsQuery, ArticleDetailsOutputModel>
        {
            private readonly IBlogData data;
            private readonly IMapper mapper;
            private readonly IIdentity identity;

            public ArticleDetailsQueryHandler(
                IBlogData data,
                IMapper mapper,
                IIdentity identity)
            {
                this.data = data;
                this.mapper = mapper;
                this.identity = identity;
            }

            public async Task<ArticleDetailsOutputModel> Handle(
                ArticleDetailsQuery request, 
                CancellationToken cancellationToken)
            {
                var articleDetails = await this.data
                    .Articles
                    .Where(a => a.Id == request.Id)
                    .ProjectTo<ArticleDetailsModel>(this.mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);

                if (articleDetails == null)
                {
                    return null;
                }

                var articleDetailsOutput = this.mapper.Map<ArticleDetailsOutputModel>(articleDetails);

                articleDetailsOutput.Author = await this.identity.GetUserName(articleDetails.CreatedBy);

                return articleDetailsOutput;
            }
        }
    }
}
