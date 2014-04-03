using System;
using RockPaperScissors.App.GameTypes;
using RockPaperScissors.App.Repository;
using RockPaperScissors.Contracts;

namespace RockPaperScissors.App
{
    public class GameValidation : IGameValidation
    {
        private readonly IAppRepository _appRepository;

        public GameValidation(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public bool IsValidGameType(string gameTypeName)
        {
            return !string.IsNullOrEmpty(gameTypeName) && _appRepository.GameTypes.ContainsKey(gameTypeName.ToLower());
        }

        public bool IsValidMoveName(string moveName)
        {
            return !string.IsNullOrEmpty(moveName) && _appRepository.MoveStrategies.ContainsKey(moveName.ToLower());
        }

        public bool IsValidPlayerType(string playerTypeName)
        {
            PlayerType playerType;
            return Enum.TryParse(playerTypeName, true, out playerType);
        }
    }
}
