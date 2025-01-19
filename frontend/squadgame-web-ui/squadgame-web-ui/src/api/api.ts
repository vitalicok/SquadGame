import { PaginatedResult, TeamDTO } from '../models/teamModel';

const API_BASE_URL = 'http://localhost:5161/api'; 

export const fetchTeams = async (league: number, seasonYear: number): Promise<PaginatedResult<TeamDTO>> => {
  try {
    const response = await fetch(`${API_BASE_URL}/teams?league=${league}&seasonYear=${seasonYear}`);
    if (!response.ok) {
      throw new Error('Failed to fetch teams');
    }

    const data = await response.json();

    return {
      Total: data.data.length,
      Entities: data.data,  
    };
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const fetchTeamPlayers = async (teamId: number): Promise<PaginatedResult<TeamDTO>> => {
  try {
    const response = await fetch(`${API_BASE_URL}/teams/id?teamId=${teamId}`);
    if (!response.ok) {
      throw new Error('Failed to fetch teams');
    }

    const data = await response.json();

    return {
      Total: data.data.length,
      Entities: data.data,  
    };
  } catch (error) {
    console.error(error);
    throw error;
  }
};