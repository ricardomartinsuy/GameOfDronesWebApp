using System;
namespace GameOfDronesWebApp.Models
{
	public class Round
	{
        public int Id { get; set; }
        public int GameId { get; set; }
        public int? WinnerId { get; set; }
        public string Player1Move { get; set; }
        public string Player2Move { get; set; }
    }
}

