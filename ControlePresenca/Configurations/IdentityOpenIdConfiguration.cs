using ControlePresenca.Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;

namespace ControlePresenca.Configurations
{
    public static class IdentityOpenIdConfiguration
    {
        public static IServiceCollection AddIdentityOpenIdConfiguration(this IServiceCollection services)
        {
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                           .UseDbContext<UserDbContext>();
                })
                .AddServer(options =>
                {
                    options.SetAuthorizationEndpointUris("/connect/authorize")
                           .SetTokenEndpointUris("/connect/token")
                           .AllowAuthorizationCodeFlow()
                           .AllowRefreshTokenFlow()
                           .RequireProofKeyForCodeExchange();

                    options.RegisterScopes(OpenIddictConstants.Scopes.Profile);
                })
                .AddValidation(options =>
                {
                    options.UseAspNetCore();
                })
                .AddValidation(options =>
                {
                    options.SetIssuer("https://accounts.google.com");

                    options.AddAudiences("686934782381-05r2o0rcdkagb151fq39r7u90a96l5ha.apps.googleusercontent.com");
                    options.UseSystemNetHttp();
                });

            return services;
        }
    }
}
