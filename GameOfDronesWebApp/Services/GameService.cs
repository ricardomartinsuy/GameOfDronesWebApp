using GameOfDronesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GameOfDronesAPI.Services
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
                Player2Id = player2.Id
            };

            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public Round PlayRound(int gameId, string player1Move, string player2Move)
        {
            var game = _context.Games.Include(g => g.Rounds).FirstOrDefault(g => g.Id == gameId);
            if (game == null) return null;

            var round = new Round
            {
                Player1Move = player1Move,
                Player2Move = player2Move,
                WinnerId = CalculateRoundWinner(player1Move, player2Move)
            };

            game.Rounds.Add(round);
            _context.SaveChanges();

            return round;
        }

        private int? CalculateRoundWinner(string player1Move, string player2Move)
        {
            if (player1Move == player2Move) return null;

            if ((player1Move == "Paper" && player2Move == "Rock") ||
                (player1Move == "Rock" && player2Move == "Scissors") ||
                (player1Move == "Scissors" && player2Move == "Paper"))
            {
                return 1; 
            }

            return 2; 
        }
    }
}
