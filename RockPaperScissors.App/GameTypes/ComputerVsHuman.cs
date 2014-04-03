using RockPaperScissors.Contracts;

namespace RockPaperScissors.App.GameTypes
{
    public class ComputerVsHuman : IGameType
    {
        public PlayerType Player1 { get { return PlayerType.Computer; } }
        public PlayerType Player2 { get { return PlayerType.Human; } }
    }
}
