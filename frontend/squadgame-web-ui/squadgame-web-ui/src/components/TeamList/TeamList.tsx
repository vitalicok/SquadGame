import React, { useEffect, useState } from 'react';
import { TeamDTO, PlayerDTO } from '../../models/teamModel';
import { loadPlayers, loadTeams } from '../../services/teamService'; 
import './TeamList.scss';
import TeamCard from '../TeamCard/TeamCard';

interface TeamListProps {
  searchTerm: string; 
  league: number;
  seasonYear: number;
}

const TeamList: React.FC<TeamListProps> = ({ searchTerm, league, seasonYear }) => {

  const [teams, setTeams] = useState<TeamDTO[]>([]);
  const [selectedTeam, setSelectedTeam] = useState<TeamDTO | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>('');
  const [players, setPlayers] = useState<PlayerDTO[]>([]);

  useEffect(() => {
    const loadTeamsData = async () => {
      setLoading(true);
      try {
        const response = await loadTeams(league, seasonYear);
        setTeams(response.Entities);
      } catch (err) {
        setError('Failed to fetch teams');
      } finally {
        setLoading(false);
      }
    };

    loadTeamsData();
  }, [league, seasonYear]);

  const filteredTeams = searchTerm
    ? teams.filter((team) => team.name.toLowerCase().includes(searchTerm.toLowerCase()) 
                    || team.nickname.toLowerCase().includes(searchTerm.toLowerCase()))
    : teams;

  const handleTeamClick = async (teamId: number) => {
    try {
      setLoading(true);
      const response = await loadPlayers(teamId);
      setPlayers(response.Entities[0]?.squad || []);
      setSelectedTeam(teams.find((team) => team.teamId === teamId) || null);
    } catch (error) {
      setError('Failed to fetch players');
    } finally {
      setLoading(false);
    }
  };

  if (loading) {
    return <p>Loading...</p>;
  }

  if (error) {
    return <p>{error}</p>;
  }

  return (
    <div>
      {selectedTeam ? (
        <div className="team-players">
          <h2>{selectedTeam.name} Players</h2>
          {players.length === 0 ? (
            <p>No players found.</p>
          ) : (
            <ul>
              {players.map((player) => (
                <li key={player.playerId}>
                  <img src={player.profilePictureUrl} alt={player.firstName} width="50" />
                  <span>{player.firstName} {player.surname}</span>
                  <span>{player.age}</span>
                  <span> - {player.position}</span>
                </li>
              ))}
            </ul>
          )}
        </div>
      ) : (

        <div className="team-list">
          {filteredTeams.length === 0 && searchTerm ? (
            <p>No teams found.</p>
          ) : (
            filteredTeams.map((team) => (
              <div key={team.teamId} className="team-item" onClick={() => handleTeamClick(team.teamId)}>
                <TeamCard team={team} />
              </div>
            ))
          )}
        </div>
      )}
    </div>
  );
};

export default TeamList;
