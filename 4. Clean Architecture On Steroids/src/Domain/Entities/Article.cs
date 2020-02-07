namespace Blog.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Exceptions;

    public class Article : AuditableEntity<int>
    {
        private string title;
        private string content;

        public Article(string title, string content, string createdBy)
        {
            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidArticleException("Article title cannot be null.");
                }

                if (value.Length > 40)
                {
                    throw new InvalidArticleException("Article title cannot be more than 40 symbols.");
                }

                this.title = value;
            }
        }

        public string Content
        {
            get => this.content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidArticleException("Article content cannot be null.");
                }

                this.content = value;
            }
        }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }

        public ICollection<Comment> Comments { get; } = new List<Comment>();

        public void AddComment(string comment, string userId)
            => this.Comments.Add(new Comment(comment, userId));
    }
}
