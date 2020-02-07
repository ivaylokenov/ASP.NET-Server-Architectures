namespace Blog.Domain
{
    using System;

    public abstract class AuditableEntity<TKey> : Entity<TKey>
    {
        private string userId;

        public string UserId
        {
            get => this.userId;
            set => this.userId = value ?? throw new InvalidOperationException("User ID cannot be null.");
        }

        public DateTime CreatedOn { get; set; }
    }
}
