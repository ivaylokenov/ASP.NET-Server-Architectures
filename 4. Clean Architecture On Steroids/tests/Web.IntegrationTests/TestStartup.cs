namespace Blog.Web.IntegrationTests
{
    using Application.Common.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyTested.AspNetCore.Mvc;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services
                .ReplaceTransient<ICurrentUser>(_ => Mocks.CurrentUser)
                .ReplaceTransient<IDateTime>(_ => Mocks.DateTime);
        }
    }
}
