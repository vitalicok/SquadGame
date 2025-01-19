using System.Text.Json.Serialization;

namespace SquadGame.Core.Service.Models
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }

        [JsonPropertyName("results")]
        public int Results { get; set; }

        [JsonPropertyName("response")]
        public List<T> Response { get; set; }
    }
}
