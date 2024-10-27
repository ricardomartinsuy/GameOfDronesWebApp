import { Round } from "./round.model";

export interface Game {
    id: number;
    player1Id: number;
    player2Id: number;
    player1Wins: number;
    player2Wins: number;
    rounds: Round[];
  }
  