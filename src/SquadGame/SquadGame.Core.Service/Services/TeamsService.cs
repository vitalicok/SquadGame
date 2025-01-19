using SquadGame.Api.Base.Configurations;
using SquadGame.Api.Base.Exceptions;
using SquadGame.Core.Service.Exceptions;
using SquadGame.Core.Service.Interfaces;
using SquadGame.Core.Service.Models;
using SquadGame.Core.Service.Models.DTOs;
using System.Text.Json;

namespace SquadGame.Core.Service.Services
{
    public class TeamsService : ITeamService
    {
        private readonly HttpClient _httpClient;
        private IFootballApiClient _footballApiClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<TeamsService> _logger;
        private readonly ITeamDTOAggregatorService _teamDTOAggregator;

        public TeamsService(HttpClient httpClient, IConfiguration configuration,
            ILogger<TeamsService> logger, IFootballApiClient footballApiClient, ITeamDTOAggregatorService teamDTOAggregator)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _footballApiClient = footballApiClient;
            _teamDTOAggregator = teamDTOAggregator;
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeamsPerLeague(int leagueId, int seasonYear, CancellationToken ct = default)
        {
            leagueId = 39; //set hardcoded league(premier league)

            try
            {
                var apiResponse = await _footballApiClient.GetTeams(leagueId, seasonYear);

                var teamDto = _teamDTOAggregator.FillInDTO(apiResponse.Data.Response);

                return teamDto ?? throw new TeamDataNotFound();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error occurred while fetching data from API");
                throw new Exception($"Error retrieving team data: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TeamDTO>> GetTeamPlayersAsync(int teamId, CancellationToken ct = default)
        {
            if (teamId <= default(int))
                throw new ArgumentException("Team id must be greater than zero");

            try
            {
                var teamPlayersResponse = await _footballApiClient.GetTeamPlayers(teamId);

                var playerIds = teamPlayersResponse.Data.Response.SelectMany(a => a.Players.Select(b => b.Id)).ToList();
                var playersProfileResponse = await _footballApiClient.GetTeamPlayersProfiles(playerIds);

                var teamResponse = _teamDTOAggregator.PopulateExtraData(playersProfileResponse.Data.Response, teamPlayersResponse.Data.Response);
                var teamDto = _teamDTOAggregator.FillInDTO(teamResponse.ToList());

                return teamDto ?? throw new TeamDataNotFound();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error occurred while fetching data from API");
                throw new Exception($"Error retrieving team data: {ex.Message}");
            }
        }
    }
}
