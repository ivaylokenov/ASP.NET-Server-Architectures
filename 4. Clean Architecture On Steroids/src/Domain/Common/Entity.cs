namespace Blog.Domain.Common
{
    public abstract class Entity<TKey>
    {
        public virtual TKey Id { get; set; }

        // Add GetHashCode(), Equals(), etc.
    }
}
