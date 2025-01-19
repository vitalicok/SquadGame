using Microsoft.AspNetCore.Http;

namespace SquadGame.Api.Base.Exceptions
{
    public class InvalidParameterException : ExceptionBase
    {
        public InvalidParameterException(string parameterName, string? value = default) : base(
            $"Invalid parameter {parameterName}. Unexpected value {value}")
        {
            ExtraData = new
            {
                parameterName,
                value
            };
        }

        public override int StatusCode => StatusCodes.Status400BadRequest;
    }
}
