namespace Blog.Web
{
    using Application;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddWebComponents(
            this IServiceCollection services)
            => services
                // .AddScoped<ICurrentUser, CurrentUserService>()
                .AddHttpContextAccessor()
                .AddConventionalServices(typeof(ServiceRegistration).Assembly);
    }
}
