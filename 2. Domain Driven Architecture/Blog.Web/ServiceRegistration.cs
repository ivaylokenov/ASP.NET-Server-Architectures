namespace Blog.Web
{
    using Articles.Presenters;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterWebComponents(this IServiceCollection services)
        {
            services
                .AddTransient<ArticleDetailsPresenter>();

            return services;
        }
    }
}
