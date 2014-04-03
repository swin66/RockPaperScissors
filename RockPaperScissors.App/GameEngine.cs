using System;
using System.Collections.Generic;
using System.Linq;
using RockPaperScissors.App.Strategies;
using RockPaperScissors.Contracts;

namespace RockPaperScissors.App
{
    public class GameEngine : IGameEngine
    {
        private readonly IAppRepository _appRepository;
        private readonly IGameValidation _gameValidation;
        private readonly Random _random;

        public GameEngine(IAppRepository appRepository, IGameValidation gameValidation)
        {
            _appRepository = appRepository;
            _gameValidation = gameValidation;
            _random = new Random();
        }

        public IDictionary<string, IGameType> GetGameTypes()
        {
            return _appRepository.GameTypes;
        }

        public IEnumerable<string> GetMoveNames()
        {
            return _appRepository.MoveStrategies.Keys;
        }

        public string GetRandomMoveName()
        {
            var moveNames = GetMoveNames().ToList();
            var moveName = moveNames.ElementAt(_random.Next(0, moveNames.Count()));
            return moveName;
        }

        public int CalculateWinner(string player1MoveName, string player2MoveName)
        {
            if (!_gameValidation.IsValidMoveName(player1MoveName)) throw new ArgumentException("player1MoveName");
            if (!_gameValidation.IsValidMoveName(player2MoveName)) throw new ArgumentException("player2MoveName");

            var player1Strategy = _appRepository.MoveStrategies[player1MoveName.ToLower()];
            var player2Strategy = _appRepository.MoveStrategies[player2MoveName.ToLower()];
            var player1StrategyResult = player1Strategy.CalculateResult(player2Strategy);

            return player1StrategyResult.MapToWinningPlayer();
        }
    }
}

