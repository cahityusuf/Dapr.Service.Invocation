using Basket.Abstraction.Services;
using Basket.Application.Services;
using Microservice.Api.Extensions;

namespace Basket.API.Helpers
{
    public static class ProgramExtensions
    {
        public static WebApplicationBuilder AddBasketApi(
            this WebApplicationBuilder builder)
        {
            builder.AddCustomSwagger();
            builder.AddCustomMvc();
            builder.AddCustomAuthentication();
            builder.AddCustomApplicationServices();

            return builder;
        }

        public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBasketService, BasketService>();

        }

        public static WebApplication UseBasketApi(this WebApplication app)
        {
            app.UseCustomSwagger();
            app.UseCloudEvents();
            app.UseCustomAuthentication();
            app.UseCors("CorsPolicy");
            app.UseCustomRoute();
            app.MapSubscribeHandler();

            return app;
        }
    }
}
