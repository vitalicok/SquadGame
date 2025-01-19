using Newtonsoft.Json;

namespace SquadGame.Api.Base.Settings
{
    public class ConsoleLoggerSettings : LoggerSettingBase
    {
        [JsonProperty("Template")] public string Template { get; set; }
    }
}
