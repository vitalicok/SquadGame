using SquadGame.Core.Service.Models;
using SquadGame.Core.Service.Models.DTOs;

namespace SquadGame.Core.Service.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDTO>> GetTeamPlayersAsync(int teamId, CancellationToken ct = default);
        Task<IEnumerable<TeamDTO>> GetAllTeamsPerLeague(int leagueId, int seasonYear, CancellationToken ct = default);
    }
}
