using RestSharp;
using SquadGame.Core.Service.Models;

namespace SquadGame.Core.Service.Interfaces
{
    public interface IFootballApiClient
    {
        Task<IRestResponse<ApiResponse<TeamResponse>>> GetTeams(int leagueId, int seasonYear, CancellationToken ct = default);
        Task<IRestResponse<ApiResponse<TeamResponse>>> GetTeamPlayers(int teamId, CancellationToken ct = default);
        Task<IRestResponse<ApiResponse<TeamResponse>>> GetTeamPlayersProfiles(IReadOnlyCollection<int> playerIds, CancellationToken ct = default);
    }
}
