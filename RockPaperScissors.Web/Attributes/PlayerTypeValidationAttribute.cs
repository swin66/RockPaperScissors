using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using RockPaperScissors.Contracts;

namespace RockPaperScissors.Web.Attributes
{
    public class PlayerTypeValidationAttribute : ValidationAttribute
    {
        private readonly IGameValidation _gameValidation;

        public PlayerTypeValidationAttribute()
        {
            _gameValidation = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IGameValidation)) as IGameValidation;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var playerType = (string) value;
            
            if (playerType == null) return new ValidationResult("Invalid player type");

            return _gameValidation.IsValidPlayerType(playerType)
                ? ValidationResult.Success 
                : new ValidationResult("Invalid player type : " + playerType);
        }
    }
}