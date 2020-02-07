namespace Blog.Infrastructure.Persistence
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class BlogDbContextSeed
    {
        public static async Task SeedAsync(
            BlogDbContext data, 
            UserManager<User> userManager)
        {
            var defaultUser = new User
            {
                UserName = "admin@dev.com", 
                Email = "admin@dev.com"
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, "Test1!");
            }

            if (data.Articles.Any())
            {
                return;
            }

            var userId = await data.Users.Select(u => u.Id).FirstAsync();

            data.Articles.Add(new Article("Test Article", "Test Article Content", userId)
            {
                CreatedOn = DateTime.Now.AddDays(-1),
                IsPublic = true,
                PublishedOn = DateTime.Now
            });

            await data.SaveChangesAsync();
        }
    }
}
