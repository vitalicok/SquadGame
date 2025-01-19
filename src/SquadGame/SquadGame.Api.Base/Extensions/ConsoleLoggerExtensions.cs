using Serilog;
using SquadGame.Api.Base.Settings;
using Serilog.Sinks.SystemConsole.Themes;

namespace SquadGame.Api.Base.Extensions
{
    public static class ConsoleLoggerExtensions
    {
        public static LoggerConfiguration UseConsoleLogger(this LoggerConfiguration configuration,
            ConsoleLoggerSettings settings)
        {
            if (configuration != null && settings is { Enabled: true })
                configuration.WriteTo
                    .Console(settings.MinLevel, settings.Template, theme: AnsiConsoleTheme.Code)
                    .Enrich.FromLogContext();

            return configuration;
        }
    }
}
