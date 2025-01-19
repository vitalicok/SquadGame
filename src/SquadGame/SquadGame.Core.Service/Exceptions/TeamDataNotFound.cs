using SquadGame.Api.Base.Exceptions;

namespace SquadGame.Core.Service.Exceptions
{
    public class TeamDataNotFound : ExceptionBase
    {
        public TeamDataNotFound() : base($"No team data found.")
        {
        }
        public override int StatusCode => StatusCodes.Status400BadRequest;
    }
}
