using System.Collections.Generic;

namespace RockPaperScissors.Contracts
{
    public interface IAppRepository
    {
        IDictionary<string, IMoveStrategy> MoveStrategies { get; }
        IDictionary<string, IGameType> GameTypes { get; }

    }
}
