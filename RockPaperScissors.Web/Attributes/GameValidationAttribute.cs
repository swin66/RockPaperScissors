using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using RockPaperScissors.Contracts;
using RockPaperScissors.Web.Models;

namespace RockPaperScissors.Web.Attributes
{
    public class GameValidationAttribute : ValidationAttribute
    {
        private readonly IGameValidation _gameValidation;
        
        public GameValidationAttribute()
        {
            _gameValidation = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IGameValidation)) as IGameValidation;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var game = value as GameModel;

            if (game == null) return new ValidationResult("Game invalid");

            var gameType = string.Format("{0}vs{1}", game.Player1Move.PlayerType.ToLower(), game.Player2Move.PlayerType.ToLower());

            if (!_gameValidation.IsValidGameType(gameType)) return new ValidationResult("Invalid game type : " + gameType);
            
            return ValidationResult.Success;
        }
    }
}
