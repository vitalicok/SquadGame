using SquadGame.Core.Service.Models;
using SquadGame.Core.Service.Models.DTOs;

namespace SquadGame.Core.Service.Interfaces
{
    public interface ITeamDTOAggregatorService
    {
        IEnumerable<TeamDTO> FillInDTO(IReadOnlyCollection<TeamResponse> teams);
        IEnumerable<TeamResponse> PopulateExtraData(IReadOnlyCollection<TeamResponse> source, IReadOnlyCollection<TeamResponse> destination);
        Dictionary<string, List<string>> GetTeamNameToNickNamePairs();
    }
}
