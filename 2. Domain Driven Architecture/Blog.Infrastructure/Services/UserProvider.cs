namespace Blog.Infrastructure.Providers
{
    using System.Linq;
    using Application.Infrastructure;
    using Persistence;

    public class UserProvider : IUserService
    {
        private readonly BlogDbContext db;

        public UserProvider(BlogDbContext db) 
            => this.db = db;

        public string GetUserName(string userId)
            => this.db
                .Users
                .Where(u => u.Id == userId)
                .Select(u => u.UserName)
                .FirstOrDefault();
    }
}
