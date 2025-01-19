using Newtonsoft.Json;

namespace SquadGame.Core.Service.Configurations
{
    public class SqlServerConfiguration
    {
        public const string SectionName = "SqlServer";

        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }
    }
}
