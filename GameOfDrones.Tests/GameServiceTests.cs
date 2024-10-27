using GameOfDronesWebApp.Models;
using GameOfDronesWebApp.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GameOfDrones.Tests
{
    public class GameServiceTests : IDisposable
    {
        private readonly GameService _gameService;
        private readonly GameDbContext _context;

        public GameServiceTests()
        {
            var options = new DbContextOptionsBuilder<GameDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new GameDbContext(options);
            _gameService = new GameService(_context);
        }

        private void SeedData()
        {
            _context.Games.Add(new Game
            {
                Player1Id = 1,
                Player2Id = 2,
                Player1Wins = 0,
                Player2Wins = 0,
                IsFinished = false
            });
            _context.SaveChanges();
        }

        [Fact]
        public void StartGame_ShouldCreateNewGame_WhenValidPlayers()
        {
            var player1 = new Player { Id = 1, Name = "Alice" };
            var player2 = new Player { Id = 2, Name = "Bob" };

            var game = _gameService.StartGame(player1, player2);

            Assert.NotNull(game);
            Assert.Equal(player1.Id, game.Player1Id);
            Assert.Equal(player2.Id, game.Player2Id);
            Assert.Empty(game.Rounds);
        }

        [Fact]
        public void ProcessRound_ShouldFinishGame_WhenPlayer1WinsThreeTimes()
        {
            var game = new Game
            {
                Player1Id = 1,
                Player2Id = 2,
                Player1Wins = 2,
                Player2Wins = 1,
                IsFinished = false
            };

            _context.Games.Add(game);
            _context.SaveChanges();

            _gameService.ProcessRound(game, "Rock", "Scissors");

            Assert.True(game.IsFinished);
            Assert.Equal(3, game.Player1Wins);
            Assert.Equal(game.Player1Id, game.Winner);
        }

        [Fact]
        public void ProcessRound_ShouldNotFinishGame_WhenNoWinner()
        {
            var game = new Game
            {
                Player1Id = 1,
                Player2Id = 2,
                Player1Wins = 2,
                Player2Wins = 2,
                IsFinished = false
            };

            _context.Games.Add(game);
            _context.SaveChanges();

            _gameService.ProcessRound(game, "Rock", "Rock");

            Assert.False(game.IsFinished); 
            Assert.Equal(2, game.Player1Wins); 
            Assert.Equal(2, game.Player2Wins); 
            Assert.Null(game.Winner); 
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
