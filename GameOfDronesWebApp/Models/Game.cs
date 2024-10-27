using System;
namespace GameOfDronesWebApp.Models
{
	public class Game
	{
        public int Id { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public List<Round> Rounds { get; set; } = new List<Round>();
    }
}

