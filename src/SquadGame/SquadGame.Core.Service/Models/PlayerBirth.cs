using System.Text.Json.Serialization;

namespace SquadGame.Core.Service.Models
{
    public class PlayerBirth
    {
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; } 

        [JsonPropertyName("place")]
        public string Place { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
