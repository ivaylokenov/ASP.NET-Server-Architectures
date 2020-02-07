namespace Blog.Infrastructure.Persistence
{
    using Domain.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BlogDbContext : IdentityDbContext<User>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
