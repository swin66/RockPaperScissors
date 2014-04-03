using System.Collections.Generic;
using RockPaperScissors.App.GameTypes;
using RockPaperScissors.App.Strategies;
using RockPaperScissors.Contracts;

namespace RockPaperScissors.App.Repository
{
    public class AppRepository : IAppRepository
    {
        private IDictionary<string, IMoveStrategy> _moveStrategies;

        public IDictionary<string, IMoveStrategy> MoveStrategies
        {
            get { return _moveStrategies ?? (_moveStrategies = GetMoveStrategies()); }
        }

        private IDictionary<string, IGameType> _gameTypes;

        public IDictionary<string, IGameType> GameTypes
        {
            get { return _gameTypes ?? (_gameTypes = GetGameTypes()); }
        }

        public IDictionary<string, IMoveStrategy> GetMoveStrategies()
        {
            // for simplicity we just build a simple dictionary of allowable move strategies
            // but this could easily be replaced with a data store or reflection to pick up strategies dynamically
            return new Dictionary<string, IMoveStrategy>
            {
                {"rock", new RockStrategy()},
                {"paper", new PaperStrategy()},
                {"scissors", new ScissorsStrategy()}
            };
        }

        public IDictionary<string, IGameType> GetGameTypes()
        {
            // for simplicity we just build a simple dictionary of allowable game types
            // but this could easily be replaced with a data store or reflection to pick up strategies dynamically
            return new Dictionary<string, IGameType>
            {
                {"computervscomputer", new ComputerVsComputer()},
                {"computervshuman", new ComputerVsHuman()},
                {"humanvscomputer", new HumanVsComputer()}
            };
        }
    }
}
