import { fetchTeamPlayers, fetchTeams } from '../api/api'; 
import { PaginatedResult, TeamDTO } from '../models/teamModel';

export const loadTeams = async (league: number, season: number): Promise<PaginatedResult<TeamDTO>> => {
  try {
    const response = await fetchTeams(league, season); 
    return response; 
  } catch (error) {
    throw new Error('Failed to load teams');
  }
};

export const loadPlayers = async (teamId: number): Promise<PaginatedResult<TeamDTO>> => {
  try {
    const response = await fetchTeamPlayers(teamId); 
    return response; 
  } catch (error) {
    throw new Error('Failed to load teams');
  }
};