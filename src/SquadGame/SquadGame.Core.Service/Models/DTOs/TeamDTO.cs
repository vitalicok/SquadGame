namespace SquadGame.Core.Service.Models.DTOs
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string LogoUrl { get; set; }
        public List<PlayerDTO> Squad { get; set; }
    }
}
