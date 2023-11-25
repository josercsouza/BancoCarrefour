using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;

namespace Carrefour.Infraestrutura.Config
{
    public static class SwaggerConfig
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            var xmlPath = Path.Combine(AppContext.BaseDirectory, "Carrefour.Aplicacao.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JRCS API", Version = "v1" });
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerApp(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocExpansion(DocExpansion.None);
                c.SwaggerEndpoint($"{(string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..")}/swagger/v1/swagger.json", "Banco Carrefour API V1");
            });
        }
    }
}
