using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquadGame.Api.Base.Configurations;

namespace SquadGame.Api.Base.Extensions
{
    public static class RateLimitExtensions
    {
        public static void AddRateLimit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddInMemoryRateLimiting();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.Configure<IpRateLimitOptions>(configuration.GetSection(RateLimitConfigurations.SectionName));

        }
    }
}
