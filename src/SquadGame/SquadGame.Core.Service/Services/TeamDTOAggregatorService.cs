using SquadGame.Core.Service.Interfaces;
using SquadGame.Core.Service.Models;
using SquadGame.Core.Service.Models.DTOs;

namespace SquadGame.Core.Service.Services
{
    public class TeamDTOAggregatorService : ITeamDTOAggregatorService
    {
        public IEnumerable<TeamDTO> FillInDTO(IReadOnlyCollection<TeamResponse> teams)
        {
            List<TeamDTO> teamDto = new();

            foreach (var teamResponse in teams)
            {
                NameToNicknamesDict.TryGetValue(teamResponse.Team.Name, out var nickNames);
                var team = new TeamDTO
                {
                    TeamId = teamResponse.Team.Id,
                    Name = teamResponse.Team.Name,
                    Nickname = nickNames != null ? string.Join(" or ", nickNames) : string.Empty,
                    LogoUrl = teamResponse.Team.Logo
                };

                if (teamResponse.Players?.Any() == true)
                    team.Squad = teamResponse.Players.Select(a => new PlayerDTO { 
                        FirstName = a.Firstname,
                        Surname = a.Lastname,
                        DateOfBirth = a.Birth?.Date,
                        Position = a.Position,
                        ProfilePictureUrl = a.Photo
                    }).ToList();

                teamDto.Add(team);
            }

            return teamDto;
        }

        public IEnumerable<TeamResponse> PopulateExtraData(IReadOnlyCollection<TeamResponse> source, IReadOnlyCollection<TeamResponse> destination)
        {
            foreach (var sourceTeam in source)
            {
                // Find the corresponding team in the destination
                var destinationTeam = destination.FirstOrDefault(d => d.Team.Id == sourceTeam.Team.Id);
                if (destinationTeam == null) continue;

                foreach (var sourcePlayer in sourceTeam.Players)
                {
                    // Check if the player exists in the destination
                    var destinationPlayer = destinationTeam.Players.FirstOrDefault(p => p.Id == sourcePlayer.Id);

                    if (destinationPlayer == null)
                    {
                        // Add missing player to destination
                        destinationTeam.Players.Add(sourcePlayer);
                    }
                    else
                    {
                        // Update player details if any are missing or incomplete
                        if (string.IsNullOrWhiteSpace(destinationPlayer.Firstname))
                            destinationPlayer.Firstname = sourcePlayer.Firstname;

                        if (string.IsNullOrWhiteSpace(destinationPlayer.Lastname))
                            destinationPlayer.Lastname = sourcePlayer.Lastname;

                        if (string.IsNullOrWhiteSpace(destinationPlayer.Position))
                            destinationPlayer.Position = sourcePlayer.Position;

                        if (destinationPlayer.Birth.Date is null)
                            destinationPlayer.Birth.Date = sourcePlayer.Birth.Date;

                        if (destinationPlayer.Birth.Country is null)
                            destinationPlayer.Birth.Country = sourcePlayer.Birth.Country;

                        if (destinationPlayer.Birth.Place is null)
                            destinationPlayer.Birth.Place = sourcePlayer.Birth.Place;

                        if (string.IsNullOrWhiteSpace(destinationPlayer.Photo))
                            destinationPlayer.Photo = sourcePlayer.Photo;
                    }
                }
            }
            return destination;
        }

        public Dictionary<string, List<string>> GetTeamNameToNickNamePairs() => NameToNicknamesDict;

        private Dictionary<string, List<string>> NameToNicknamesDict { get; init; } = new() {
            { "Arsenal", new List<string> { "The Gunners" } },
            { "Aston Villa", new List<string> { "The Villans" } },
            { "Bournemouth", new List<string> { "The Cherries" } },
            { "Brentford", new List<string> { "The Bees" } },
            { "Brighton", new List<string> { "The Seagulls" } },
            { "Burnley", new List<string> { "The Clarets" } },
            { "Chelsea", new List<string> { "The Blues" } },
            { "Crystal Palace", new List<string> { "The Eagles" } },
            { "Everton", new List<string> { "The Toffees" } },
            { "Fulham", new List<string> { "The Cottagers" } },
            { "Liverpool", new List<string> { "The Reds" } },
            { "Luton", new List<string> { "The Hatters" } },
            { "Manchester City", new List<string> { "The Citizens", "Cityzens" } },
            { "Manchester United", new List<string> { "The Red Devils" } },
            { "Newcastle", new List<string> { "The Magpies" } },
            { "Nottingham Forest", new List<string> { "The Tricky Trees", "Forest" } },
            { "Sheffield Utd", new List<string> { "The Blades" } },
            { "Tottenham", new List<string> { "Spurs", "The Lilywhites" } },
            { "West Ham", new List<string> { "The Hammers", "The Irons" } },
            { "Wolves", new List<string> { "Wolves" } }
        };
    }
}
