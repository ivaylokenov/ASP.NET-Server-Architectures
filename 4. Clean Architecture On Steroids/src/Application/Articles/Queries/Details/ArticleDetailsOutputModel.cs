namespace Blog.Application.Articles.Queries.Details
{
    using System;
    using Common.Mappings;

    public class ArticleDetailsOutputModel : IMapFrom<ArticleDetailsModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }

        public string Author { get; set; }
    }
}
