namespace Blog.Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                .Property(a => a.CreatedBy)
                .IsRequired();

            builder
                .HasMany(a => a.Comments)
                .WithOne()
                .HasForeignKey("ArticleId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(typeof(User))
                .WithMany("Articles")
                .HasForeignKey("CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
