using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microservice.Api.OpenApi
{
    public class ConfigureSwaggerGenerationOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Bağımlılıkları başlatır.
        /// </summary>
        /// <param name="configuration">Konfigürasyondan gelecek identity provider bilgileri için kullanlır</param>
        /// <param name="httpClientFactory">Identity provider keşfi için kullanılır</param>
        public ConfigureSwaggerGenerationOptions(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Swagger içi authorization grant flow konfigürasyonunu yapar
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = _configuration["OpenApi:Title"], Version = _configuration["OpenApi:Version"] });

            options.OperationFilter<AuthorizeCheckOperationFilter>();
        }
    }
}
