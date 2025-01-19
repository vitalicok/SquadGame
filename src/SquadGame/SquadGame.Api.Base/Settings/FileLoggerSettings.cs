using Newtonsoft.Json;

namespace SquadGame.Api.Base.Settings
{
    public class FileLoggerSettings : LoggerSettingBase
    {
        [JsonProperty("Path")] public string Path { get; set; }
    }
}
