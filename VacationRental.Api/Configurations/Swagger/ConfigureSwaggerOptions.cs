﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace VacationRental.Api.Configurations.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            _provider.ApiVersionDescriptions
                .ToList()
                .ForEach(act =>
                {
                    var info = new OpenApiInfo
                    {
                        Title = "Vacation rental information API",
                        Version = act.ApiVersion.ToString()
                    };

                    options.SwaggerDoc(act.GroupName, info);
                });
        }
    }
}
