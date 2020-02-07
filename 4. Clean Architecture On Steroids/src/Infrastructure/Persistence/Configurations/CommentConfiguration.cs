namespace Blog.Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Content)
                .IsRequired();

            builder
                .Property(a => a.CreatedBy)
                .IsRequired();

            builder
                .HasOne(typeof(User))
                .WithMany("Comments")
                .HasForeignKey("CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
