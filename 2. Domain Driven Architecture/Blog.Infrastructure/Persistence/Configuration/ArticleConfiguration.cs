namespace Blog.Infrastructure.Persistence.Configuration
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Title)
                .IsRequired();

            builder
                .Property(a => a.Content)
                .IsRequired();

            builder
                .HasMany(a => a.Comments)
                .WithOne()
                .HasForeignKey("ArticleId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(typeof(User))
                .WithMany("Articles")
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
