using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using VacationRental.Api.Configurations.Swagger;
using VacationRental.Infra.CrossCutting.IoC;

namespace VacationRental.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostEnvironment env)
        {
            var environmentName = env.EnvironmentName;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appSettings.{(string.IsNullOrEmpty(environmentName) ? "Development" : environmentName)}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup))
                .ConfigureContainer()
                .AddResponseCompression()
                .AddRouting()
                .AddHealthChecks()
                .Services
                .AddApiVersioning(options => options.ReportApiVersions = true)
                .AddVersionedApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                })
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                .AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
               .ConfigureSwagger(_configuration, provider)
               .UseEndpoints(enpoints => enpoints.MapControllers())
               .UseHealthChecks("/healthcheck");;
        }
    }
}
