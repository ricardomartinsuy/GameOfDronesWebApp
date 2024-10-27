using Microsoft.AspNetCore.Mvc;
using GameOfDronesAPI.Services;
using GameOfDronesWebApp.Models;

namespace GameOfDronesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;
        private readonly GameDbContext _context;

        public GameController(GameService gameService, GameDbContext context)
        {
            _gameService = gameService;
            _context = context;
        }

        [HttpPost("start")]
        public ActionResult<Game> StartGame([FromBody] GameRequest request)
        {
            var game = _gameService.StartGame(request.Player1, request.Player2);
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        [HttpPost("play/{gameId}")]
        public ActionResult<Round> PlayRound(int gameId, [FromBody] Round round)
        {
            var result = _gameService.PlayRound(gameId, round.Player1Move, round.Player2Move);
            if (result == null) return NotFound();
            return CreatedAtAction(nameof(PlayRound), new { id = gameId }, result);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGame(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            return game;
        }

        [HttpGet("round/{id}")]
        public ActionResult<Round> GetRound(int id)
        {
            var round = _context.Rounds.Find(id); 
            if (round == null)
            {
                return NotFound();
            }
            return round;
        }
    }
}
