using GameOfDronesWebApp.Models; 
using Microsoft.EntityFrameworkCore; 

namespace GameOfDronesWebApp.Services
{
    public class GameService
    {
        private readonly GameDbContext _context;

        public GameService(GameDbContext context)
        {
            _context = context;
        }

        public Game StartGame(Player player1, Player player2)
        {
            var game = new Game
            {
                Player1Id = player1.Id,
                Player2Id = player2.Id,
                Player1Wins = 0,
                Player2Wins = 0,
                Rounds = new List<Round>()
            };

            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        // Play a round of the game
        public Round PlayRound(int gameId, string player1Move, string player2Move)
        {
            var game = _context.Games.Include(g => g.Rounds).FirstOrDefault(g => g.Id == gameId);
            if (game == null) return null;

            var round = new Round
            {
                Player1Move = player1Move,
                Player2Move = player2Move,
                Winner = DetermineWinner(player1Move, player2Move)
            };

            game.Rounds.Add(round);
            UpdateGameScore(game, round.Winner);
            _context.SaveChanges(); 
            return round;
        }

        public void ProcessRound(Game game, string player1Move, string player2Move)
        {
            string roundWinner = DetermineWinner(player1Move, player2Move);

            if (roundWinner == "Player1")
            {
                game.Player1Wins++;
                game.Rounds.Add(new Round { WinnerId = game.Player1Id });
            }
            else if (roundWinner == "Player2")
            {
                game.Player2Wins++;
                game.Rounds.Add(new Round { WinnerId = game.Player2Id });
            }

            if (game.Player1Wins == 3)
            {
                game.Winner = game.Player1Id; 
                game.IsFinished = true; 
            }
            else if (game.Player2Wins == 3)
            {
                game.Winner = game.Player2Id; 
                game.IsFinished = true; 
            }
        }

        private string DetermineWinner(string move1, string move2)
        {
            if (move1 == "Rock" && move2 == "Scissors") return "Player1";
            if (move1 == "Scissors" && move2 == "Paper") return "Player1";
            if (move1 == "Paper" && move2 == "Rock") return "Player1";

            if (move2 == "Rock" && move1 == "Scissors") return "Player2";
            if (move2 == "Scissors" && move1 == "Paper") return "Player2";
            if (move2 == "Paper" && move1 == "Rock") return "Player2";

            return "Draw"; 
        }


        private void UpdateGameScore(Game game, string winner)
        {
            if (winner == "Player1")
            {
                game.Player1Wins++;
            }
            else if (winner == "Player2")
            {
                game.Player2Wins++;
            }

            if (game.Player1Wins == 3 || game.Player2Wins == 3)
            {
                game.IsFinished = true; 
                game.Winner = game.Player1Wins == 3 ? game.Player1Id : game.Player2Id; 
            }
        }

        public Game GetGame(int gameId)
        {
            return _context.Games
                .Include(g => g.Rounds) 
                .FirstOrDefault(g => g.Id == gameId);
        }
    }
}
