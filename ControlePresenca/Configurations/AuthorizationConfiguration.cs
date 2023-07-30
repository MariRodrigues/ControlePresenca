using Microsoft.Extensions.DependencyInjection;

namespace ControlePresenca.Configurations
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection AddAuthorizationConfiguration(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole("admin");
                });
            });

            return services;
        }
    }
}
