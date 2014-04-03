using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using RockPaperScissors.Contracts;
using RockPaperScissors.Web.Models;

namespace RockPaperScissors.Web.Attributes
{
    public class PlayerMoveValidationAttribute : ValidationAttribute
    {
        private readonly IGameEngine _gameEngine;

        public PlayerMoveValidationAttribute()
        {
            _gameEngine = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IGameEngine)) as IGameEngine;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var playerMove = value as PlayerMoveModel;

            if (playerMove == null) return new ValidationResult("Player move invalid");

            EnsureComputerMove(playerMove);

            return ValidationResult.Success;
        }

        private void EnsureComputerMove(PlayerMoveModel playerMove)
        {
            if (!playerMove.PlayerType.Equals(PlayerType.Computer.ToString(), StringComparison.OrdinalIgnoreCase)) return;
                
            if (string.IsNullOrEmpty(playerMove.MoveName))
            {
                playerMove.MoveName = _gameEngine.GetRandomMoveName();
            }
        }
    }
}
