using System.Collections.Generic;
using RockPaperScissors.App.GameTypes;
using RockPaperScissors.App.Strategies;

namespace RockPaperScissors.App.Repository
{
    public interface IAppRepository
    {
        IDictionary<string, IMoveStrategy> MoveStrategies { get; }
        IDictionary<string, IGameType> GameTypes { get; }

    }
}
