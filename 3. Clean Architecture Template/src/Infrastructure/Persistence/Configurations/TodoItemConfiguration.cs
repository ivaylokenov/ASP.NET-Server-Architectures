using DefaultTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultTemplate.Infrastructure.Persistence.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
