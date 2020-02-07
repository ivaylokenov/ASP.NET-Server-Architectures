namespace Blog.Application.Articles
{
    using System.Threading.Tasks;
    using Domain.Entities;

    public interface IArticleGateway
    {
        Task<Article> Details(int id);
    }
}
