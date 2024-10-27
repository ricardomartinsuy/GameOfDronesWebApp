using System;
namespace GameOfDronesWebApp.Models
{
	public class Player
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; } = 0;
	}
}

