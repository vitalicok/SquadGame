namespace SquadGame.Api.Base.Configurations
{
    public class SquadApiConfigurations
    {
        public const string SectionName = "SquadApi"; 
        public string Host { get; set; }
        public string TeamsSuffixUrl { get; set; }
        public string SquadsSuffixUrl { get; set; }
        public string PlayerProfileUrl { get; set; }
        public string ApiKey { get; set; }
    }
}
