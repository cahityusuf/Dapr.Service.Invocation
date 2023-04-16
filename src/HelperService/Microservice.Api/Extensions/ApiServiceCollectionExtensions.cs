using Microservice.Api.OpenApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microservice.Api.Extensions
{
    public static class ApiServiceCollectionExtensions
    {
        public static void AddCustomSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenerationOptions>();

            builder.Services.AddSwaggerGen(c =>
            {
                c.OperationFilter<AuthorizeCheckOperationFilter>();
            });
        }

        public static void AddCustomMvc(this WebApplicationBuilder builder)
        {
            // TODO DaprClient good enough?
            builder.Services.AddControllers(opts =>
            {
                var authenticatedUserPolicy = new AuthorizationPolicyBuilder()
                      .RequireAuthenticatedUser()
                      .Build();
                opts.Filters.Add(new AuthorizeFilter(authenticatedUserPolicy));
                opts.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

            }).AddDapr();
        }

        public static void AddCustomAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                builder.Configuration.Bind("Security:Jwt", options);
            });
        }


    }
}
