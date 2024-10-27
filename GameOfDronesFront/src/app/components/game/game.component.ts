import { Component } from '@angular/core';
import { GameService } from '../../services/game.service';
import { Game } from '../../models/game.model'; 
import { Round } from '../../models/round.model';
import { GameStartRequest } from '../../models/game-start-request.model';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent {
  gameStarted = false;
  player1Move: string = '';
  player2Move: string = '';
  gameResult: string = '';

  constructor(private gameService: GameService) {}

  startGame(player1Name: string, player2Name: string) {
    const request: GameStartRequest = {
      player1: { name: player1Name },
      player2: { name: player2Name },
    };
  
    console.log('Requisição para iniciar o jogo:', request); 
  
    this.gameService.startGame(request).subscribe(
      (response) => {
        console.log('Jogo iniciado com sucesso:', response);
      },
      (error) => {
        console.error('Erro ao iniciar o jogo:', error);
      }
    );
  }

  playRound(player1Move: string, player2Move: string) {
    // Lógica para jogar uma rodada
    console.log('Jogando rodada:', { player1Move, player2Move });

    // Você deve implementar a lógica de chamada à API para jogar a rodada aqui,
    // semelhante à chamada para iniciar o jogo.
    // Exemplo:
    // this.gameService.playRound({ player1Move, player2Move }).subscribe(
    //   (response) => {
    //     // Processar a resposta
    //     console.log('Rodada jogada com sucesso:', response);
    //     this.gameResult = `Resultado: ${response.winner}`;
    //   },
    //   (error) => {
    //     console.error('Erro ao jogar a rodada:', error);
    //   }
    // );
  }

  endGame() {
    // Lógica para finalizar o jogo
    console.log('Finalizando o jogo');
    this.gameStarted = false; // Redefinir estado do jogo
    this.player1Move = '';
    this.player2Move = '';
    this.gameResult = ''; // Limpar o resultado do jogo
  }
}
