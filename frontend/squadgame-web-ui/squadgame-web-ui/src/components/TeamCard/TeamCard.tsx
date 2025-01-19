import React from 'react';
import { TeamDTO } from '../../models/teamModel';
import './TeamCard.scss';

interface TeamCardProps {
  team: TeamDTO;
}

const TeamCard: React.FC<TeamCardProps> = ({ team }) => {
  return (
    <div className="team-card">
      <img src={team.logoUrl} alt={`${team.name} `} />
      <h3>{team.name}</h3>
      <p>{team.nickname}</p>
    </div>
  );
};

export default TeamCard;