using DefaultTemplate.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultTemplate.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "jason@clean-architecture", Email = "jason@clean-architecture" };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, "DefaultTemplate!");
            }
        }
    }
}
