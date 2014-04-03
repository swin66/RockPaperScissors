using System.Collections.Generic;

namespace RockPaperScissors.Contracts
{
    public interface IGameEngine
    {
        IDictionary<string, IGameType> GetGameTypes();
        IEnumerable<string> GetMoveNames();
        string GetRandomMoveName();
        int CalculateWinner(string player1MoveName, string player2MoveName);
    }
}
