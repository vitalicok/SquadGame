using System.Text.Json.Serialization;

namespace SquadGame.Core.Service.Models.DTOs
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string ProfilePictureUrl { get; set; }
        [JsonPropertyName("name")]
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Position { get; set; }
    }
}
