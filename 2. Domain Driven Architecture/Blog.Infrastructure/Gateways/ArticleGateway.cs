namespace Blog.Infrastructure.Gateways
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Articles;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    public class ArticleGateway : IArticleGateway
    {
        private readonly BlogDbContext db;

        public ArticleGateway(BlogDbContext db) 
            => this.db = db;

        public async Task<Article> Details(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
    }
}
