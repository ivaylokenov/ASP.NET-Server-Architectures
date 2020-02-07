namespace Blog.Application.Articles.Queries.Details
{
    using System;
    using Common.Mappings;
    using Domain.Entities;

    public class ArticleDetailsModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }

        public string CreatedBy { get; set; }
    }
}
