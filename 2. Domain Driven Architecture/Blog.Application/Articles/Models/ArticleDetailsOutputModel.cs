namespace Blog.Application.Articles.Models
{
    using System;

    public class ArticleDetailsOutputModel
    {
        public ArticleDetailsOutputModel(
            int id,
            string title,
            string content,
            bool isPublic,
            DateTime? publishedOn,
            string author)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.IsPublic = isPublic;
            this.PublishedOn = publishedOn;
            this.Author = author;
        }

        public int Id { get; }

        public string Title { get; }

        public string Content { get; }

        public bool IsPublic { get; }

        public DateTime? PublishedOn { get; }

        public string Author { get; }
    }
}
