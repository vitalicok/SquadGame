using Microsoft.Extensions.DependencyInjection;

namespace SquadGame.Api.Base.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddAPICors(this IServiceCollection services, List<string> allowedOrigins)
        {
            if (allowedOrigins != null && allowedOrigins.Any() && allowedOrigins.All(o => o != "*"))
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder
                            .WithOrigins(allowedOrigins.ToArray())
                            .SetIsOriginAllowed(s => true)
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .Build();
                    });
                });
            else
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .SetIsOriginAllowed(s => true)
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .Build();
                    });
                });

            return services;
        }
    }
}
