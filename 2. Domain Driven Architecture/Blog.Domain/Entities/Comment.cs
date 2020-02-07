namespace Blog.Domain.Entities
{
    using System;
    using Exceptions;

    public class Comment : AuditableEntity<int>
    {
        private string content;

        public Comment(string content, string userId)
        {
            this.Content = content;
            this.UserId = userId;
        }

        public string Content
        {
            get => this.content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidArticleException("Comment content cannot be null.");
                }

                this.content = value;
            }
        }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }
    }
}
