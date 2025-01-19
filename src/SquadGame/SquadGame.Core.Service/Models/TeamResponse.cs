using System.Text.Json.Serialization;

namespace SquadGame.Core.Service.Models
{
    public class TeamResponse
    {
        [JsonPropertyName("team")]
        public Team Team { get; set; }

        [JsonPropertyName("players")]
        public List<Player> Players { get; set; }
    }
}
