namespace Blog.Application
{
    using Articles.Handlers;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddTransient<IArticleDetailsInputPort, ArticleDetailsHandler>();

            return services;
        }
    }
}
