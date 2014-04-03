using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using RockPaperScissors.Contracts;

namespace RockPaperScissors.Web.Attributes
{
    public class MoveNameValidationAttribute : ValidationAttribute
    {
        private readonly IGameValidation _gameValidation;

        public MoveNameValidationAttribute()
        {
            _gameValidation = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IGameValidation)) as IGameValidation;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var moveName = (string)value;

            if (string.IsNullOrEmpty(moveName)) return ValidationResult.Success;

            return _gameValidation.IsValidMoveName((string)value) 
                ? ValidationResult.Success 
                : new ValidationResult("Invalid move name");
        }
    }
}