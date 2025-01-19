using RestSharp;
using SquadGame.Api.Base.Configurations;
using SquadGame.Api.Base.Exceptions;
using SquadGame.Core.Service.Interfaces;
using SquadGame.Core.Service.Models;
using System.Text;

namespace SquadGame.Core.Service.Client
{
    public class FootballApiClient : APIClientBase, IFootballApiClient
    {
        private readonly ILogger<FootballApiClient> _logger;
        private readonly SquadApiConfigurations _configuration;

        public FootballApiClient(SquadApiConfigurations squadApiConfigurations, ILogger<FootballApiClient> logger = null) : base(squadApiConfigurations)
        {
            _logger = logger;
            _configuration = squadApiConfigurations;
        }

        public async Task<IRestResponse<ApiResponse<TeamResponse>>> GetTeams(int leagueId, int seasonYear, CancellationToken ct = default)
        {
            var apiRequestUrl = $"{GetBaseUrl()}{_configuration.TeamsSuffixUrl}?league={leagueId}&season={seasonYear}";

            var requestApi = CreateRequest(apiRequestUrl);
            var restClient = new RestClient(GetBaseUrl());

            _logger?.LogInformation($"[{nameof(FootballApiClient)}] Attempting to fetch data from API");
            var responseApi = await restClient.ExecuteGetAsync<ApiResponse<TeamResponse>>(requestApi);

            if (!responseApi.IsSuccessful)
            {
                _logger?.LogError($"[{nameof(FootballApiClient)}] Failed to fetch data from API. Error: {responseApi.Content}");
                throw new ApiException($"Failed to fetch data: {responseApi.Content}");
            }

            _logger?.LogInformation("Successfully fetched data from API");

            return responseApi;
        }

        public async Task<IRestResponse<ApiResponse<TeamResponse>>> GetTeamPlayers(int teamId, CancellationToken ct = default)
        {
            var apiRequestUrl = $"{GetBaseUrl()}{_configuration.SquadsSuffixUrl}?team={teamId}";

            var requestApi = CreateRequest(apiRequestUrl);
            var restClient = new RestClient(GetBaseUrl());

            _logger?.LogInformation($"[{nameof(FootballApiClient)}] Attempting to fetch data from API");
            var responseApi = await restClient.ExecuteGetAsync<ApiResponse<TeamResponse>>(requestApi, ct);

            if (!responseApi.IsSuccessful)
            {
                _logger?.LogError($"[{nameof(FootballApiClient)}] Failed to fetch data from API. Error: {responseApi.Content}");
                throw new ApiException($"Failed to fetch data: {responseApi.Content}");
            }

            _logger?.LogInformation("Successfully fetched data from API");

            return responseApi;
        }

        public async Task<IRestResponse<ApiResponse<TeamResponse>>> GetTeamPlayersProfiles(IReadOnlyCollection<int> playerIds, CancellationToken ct = default)
        {
            var apiRequestUrl = new StringBuilder($"{GetBaseUrl()}{_configuration.PlayerProfileUrl}?player=");

            foreach (var playerId in playerIds)
                apiRequestUrl.Append($"{playerId},");

            if (playerIds.Any())
                apiRequestUrl.Length--;

            var requestApi = CreateRequest(apiRequestUrl.Length--.ToString());
            var restClient = new RestClient(GetBaseUrl());

            _logger?.LogInformation($"[{nameof(FootballApiClient)}] Attempting to fetch data from API");
            var responseApi = await restClient.ExecuteGetAsync<ApiResponse<TeamResponse>>(requestApi, ct);

            if (!responseApi.IsSuccessful)
            {
                _logger?.LogError($"[{nameof(FootballApiClient)}] Failed to fetch data from API. Error: {responseApi.Content}");
                throw new ApiException($"Failed to fetch data: {responseApi.Content}");
            }

            _logger?.LogInformation("Successfully fetched data from API");

            return responseApi;
        }
    }
}
