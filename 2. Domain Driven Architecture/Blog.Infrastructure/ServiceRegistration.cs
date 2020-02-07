namespace Blog.Infrastructure
{
    using Application.Articles;
    using Application.Infrastructure;
    using Gateways;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Providers;
    using Services;

    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services
                .AddDbContext<BlogDbContext>(options => options
                    .UseInMemoryDatabase("InMemoryBlogDatabase"));

            services
                .AddTransient(typeof(ILogger<>), typeof(Logger<>))
                .AddTransient<IUserService, UserProvider>();

            services
                .AddTransient<IArticleGateway, ArticleGateway>();

            return services;
        }
    }
}
