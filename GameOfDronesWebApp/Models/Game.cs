namespace GameOfDronesWebApp.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int Player1Wins { get; set; } = 0; 
        public int Player2Wins { get; set; } = 0; 
        public bool IsFinished { get; set; } = false;
        public int? Winner { get; set; }
        public List<Round> Rounds { get; set; } = new List<Round>();
    }
}
