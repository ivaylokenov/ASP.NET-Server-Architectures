namespace Blog.Infrastructure
{
    using Application;
    using Application.Common.Interfaces;
    using Identity;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Services;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services
                .AddDbContext<BlogDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"), 
                        b => b.MigrationsAssembly(typeof(BlogDbContext).Assembly.FullName)))
                .AddScoped<IBlogData>(provider => provider.GetService<BlogDbContext>());

            services
                .AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<BlogDbContext>();

            services
                .AddIdentityServer()
                .AddApiAuthorization<User, BlogDbContext>();

            services
                .AddConventionalServices(typeof(ServiceRegistration).Assembly);

            // services
            //    .AddTransient<IDateTime, DateTimeService>()
            //    .AddTransient<IIdentity, IdentityService>();

            services
                .AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
