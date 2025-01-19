using Microsoft.AspNetCore.Http;

namespace SquadGame.Api.Base.Exceptions
{
    public class ConfigurationException : ExceptionBase
    {
        public ConfigurationException(string configName) : base(
            $"{configName} is misconfigured")
        {
            ExtraData = new
            {
                configName,
            };
        }

        public override int StatusCode => StatusCodes.Status500InternalServerError;
    }
}
