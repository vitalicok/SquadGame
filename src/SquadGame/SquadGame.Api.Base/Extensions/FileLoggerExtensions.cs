using Serilog;
using SquadGame.Api.Base.Settings;

namespace SquadGame.Api.Base.Extensions
{
    public static class FileLoggerExtensions
    {
        public static LoggerConfiguration UseFileLogger(this LoggerConfiguration configuration,
            FileLoggerSettings settings)
        {
            if (configuration != null && settings is { Enabled: true })
                configuration
                    .WriteTo
                    .File(settings.Path, settings.MinLevel, rollingInterval: RollingInterval.Day)
                    .Enrich.FromLogContext(); ;

            return configuration;
        }
    }
}
