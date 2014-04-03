using RockPaperScissors.Contracts;

namespace RockPaperScissors.Web.Models
{
    public class GameTypeModel
    {
        public string Name { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }

        public GameTypeModel()
        {
            
        }

        public GameTypeModel(string name, IGameType gameType)
        {
            Name = name;
            Player1 = gameType.Player1.ToString();
            Player2 = gameType.Player2.ToString();
        }
    }
}