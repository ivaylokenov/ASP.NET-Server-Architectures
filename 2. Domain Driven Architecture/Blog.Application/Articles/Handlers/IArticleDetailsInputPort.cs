namespace Blog.Application.Articles.Handlers
{
    using Models;
    using Ports;

    public interface IArticleDetailsInputPort : IInputPort<int, ArticleDetailsOutputModel>
    {
    }
}
