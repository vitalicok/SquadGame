using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SquadGame.Api.Base.Exceptions;
using SquadGame.Api.Base.Responses;
using SquadGame.Core.Service.Interfaces;
using SquadGame.Core.Service.Models.Requests;

namespace SquadGame.Core.Service.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/teams")]
    [Route("api/v{version:apiVersion}/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SuccessResult<GetTeamResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> GetTeams([FromQuery] GetTeamRequest query)
        {
            if (query == null) throw new InvalidParameterException(nameof(query));
            if (query.SeasonYear > DateTime.UtcNow.Year) throw new ArgumentOutOfRangeException(nameof(query.SeasonYear));

            var response = await _teamService.GetAllTeamsPerLeague(query.League, query.SeasonYear);

            return new SuccessResult(response);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(SuccessResult<GetTeamResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> GetPlayersPerTeam([FromQuery] GetPlayersRequest query)
        {
            if (query == null) throw new InvalidParameterException(nameof(query));

            var response = await _teamService.GetTeamPlayersAsync(query.TeamId);

            return new SuccessResult(response);
        }
    }
}
