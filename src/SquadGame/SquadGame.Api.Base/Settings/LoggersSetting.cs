using Newtonsoft.Json;

namespace SquadGame.Api.Base.Settings
{
    public class LoggersSetting
    {
        [JsonIgnore] public const string SectionName = "Loggers";

        [JsonProperty("FileLogger")] public FileLoggerSettings FileLogger { get; set; }

        [JsonProperty("ConsoleLogger")] public ConsoleLoggerSettings ConsoleLogger { get; set; }

        //ToDo: add AppInsights once available
    }
}
