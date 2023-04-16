using Microservice.Api.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Api.Extensions
{
    public static class ApiApplicationBuilderExtensions
    {

        public static void UseCustomSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{app.Configuration.GetValue<string>("OpenApi:Title")} V1");
                c.OAuthClientId("basketswaggerui");
                c.OAuthAppName("Basket Swagger UI");
            });
        }

        public static void UseCustomAuthentication(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public static void UseCustomRoute(this WebApplication app)
        {
            app.MapDefaultControllerRoute();
            app.MapControllers();
        }
    }
}
