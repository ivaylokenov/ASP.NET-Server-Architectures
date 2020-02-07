namespace Blog.Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IBlogData
    {
        DbSet<Article> Articles { get; set; }

        DbSet<Comment> Comments { get; set; }

        Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
