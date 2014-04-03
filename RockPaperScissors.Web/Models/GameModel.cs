using System.ComponentModel.DataAnnotations;
using RockPaperScissors.Web.Attributes;

namespace RockPaperScissors.Web.Models
{
    [GameValidation]
    public class GameModel
    {
        [Required]
        public PlayerMoveModel Player1Move { get; set; }
        [Required]
        public PlayerMoveModel Player2Move { get; set; }
    }
}
