namespace Blog.Application.Common.Interfaces
{
    using System.Threading.Tasks;
    using Models;
    using Services;

    public interface IIdentity : IService
    {
        Task<string> GetUserName(string userId);

        Task<(Result Result, string UserId)> CreateUser(string userName, string password);

        Task<Result> DeleteUser(string userId);
    }
}
