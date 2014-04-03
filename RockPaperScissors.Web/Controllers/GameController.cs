using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RockPaperScissors.Contracts;
using RockPaperScissors.Web.Models;

namespace RockPaperScissors.Web.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameEngine _gameEngine;

        public GameController(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public IEnumerable<GameTypeModel> GetGameTypes()
        {
            var gameTypes = _gameEngine.GetGameTypes();
            return gameTypes.Select(gameType => new GameTypeModel(gameType.Key, gameType.Value));
        }

        public IEnumerable<string> GetMoveNames()
        {
            return _gameEngine.GetMoveNames();
        }

        public string GetRandomMoveName()
        {
            return _gameEngine.GetRandomMoveName();
        }

        public GameResultModel Post([FromBody]GameModel game)
        {
            var winningPlayerNumber = _gameEngine.CalculateWinner(game.Player1Move.MoveName, game.Player2Move.MoveName);
            var gameResult = new GameResultModel(winningPlayerNumber, game.Player1Move.MoveName, game.Player2Move.MoveName);

            return gameResult;
        }
    }
}