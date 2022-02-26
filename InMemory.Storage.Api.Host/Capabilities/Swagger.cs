using System;
using InMemory.Storage.Api.Host.OperationFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace InMemory.Storage.Api.Host.Capabilities
{
    public static class Swagger
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "In Memory Storage API",
                    Version = "v1",
                    Description = "API which allows to perform CRUD operations and stores result in memory.",
                    Contact = new OpenApiContact
                    {
                        Name = "Erikas Neverdauskas",
                        Email = "erikasnever@hotmail.com",
                        Url = new Uri("https://github.com/erinev"),
                    },
                });
                c.OperationFilter<RemoveVersionParameterFilter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();
                c.EnableAnnotations();
            }); 
        }

        public static IApplicationBuilder AddSwaggerUi(this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "In Memory Storage API v1");
                    c.RoutePrefix = "swagger";
                });
        }
    }
}
