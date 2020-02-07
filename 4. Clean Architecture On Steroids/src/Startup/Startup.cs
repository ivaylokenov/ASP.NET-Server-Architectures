namespace Blog
{
    using Application;
    using Application.Common.Interfaces;
    using FluentValidation.AspNetCore;
    using Infrastructure;
    using Infrastructure.Persistence;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Web;
    using Web.Middleware;

    public class Startup
    {
        public Startup(IConfiguration configuration) 
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApplication()
                .AddInfrastructure(this.Configuration)
                .AddWebComponents();

            services
                .AddHealthChecks()
                .AddDbContextCheck<BlogDbContext>();

            services
                .AddControllers()
                .AddFluentValidation(options => options
                    .RegisterValidatorsFromAssemblyContaining<IBlogData>())
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCustomExceptionHandler();
            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
