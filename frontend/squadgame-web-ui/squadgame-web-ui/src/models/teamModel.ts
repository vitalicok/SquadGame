export interface PlayerDTO {
    playerId: number;
    profilePictureUrl: string;
    firstName: string;
    surname: string;
    dateOfBirth?: string;
    position: string;
  }
  
  export interface TeamDTO {
    teamId: number;
    name: string;
    nickname: string;
    logoUrl: string;
    squad: PlayerDTO[];
  }
  
  export interface PaginatedResult<TEntity> {
    Total: number;
    Entities: TEntity[];
  }