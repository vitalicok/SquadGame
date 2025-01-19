namespace SquadGame.Core.Service.Configurations
{
    public class ServiceConfigurations
    {
        public const string SectionName = "Service";

        public string AuthType { get; set; }
        public List<string> AllowedOrigins { get; set; }
    }
}
