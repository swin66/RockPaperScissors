using System.ComponentModel.DataAnnotations;
using RockPaperScissors.Web.Attributes;

namespace RockPaperScissors.Web.Models
{
    [PlayerMoveValidation]
    public class PlayerMoveModel
    {
        [Required]
        [PlayerTypeValidation]
        public string PlayerType { get; set; }

        [MoveNameValidation]
        public string MoveName { get; set; }
    }
}
