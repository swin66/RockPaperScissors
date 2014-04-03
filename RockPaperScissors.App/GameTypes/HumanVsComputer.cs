using RockPaperScissors.Contracts;

namespace RockPaperScissors.App.GameTypes
{
    public class HumanVsComputer : IGameType
    {
        public PlayerType Player1 { get { return PlayerType.Human; } }
        public PlayerType Player2 { get { return PlayerType.Computer; } }
    }
}
