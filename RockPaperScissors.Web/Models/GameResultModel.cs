namespace RockPaperScissors.Web.Models
{
    public class GameResultModel
    {
        public string Player1Move { get; set; }
        public string Player2Move { get; set; }
        public int WinningPlayerNumber { get; set; }
        public string Message { get; set; }

        public GameResultModel(int winningPlayerNumber, string player1Move, string player2Move)
        {
            WinningPlayerNumber = winningPlayerNumber;
            Player1Move = player1Move;
            Player2Move = player2Move;
            Message = GetMessage(winningPlayerNumber, player1Move, player2Move);
        }

        private string GetMessage(int winningPlayerNumber, string player1Move, string player2Move)
        {
            return (winningPlayerNumber == 0)
                ? string.Format("It's a draw, both players played {0}", player1Move)
                : (winningPlayerNumber == 1)
                    ? string.Format("Player 1 wins because {0} beats {1}", player1Move, player2Move)
                    : string.Format("Player 2 wins because {0} beats {1}", player2Move, player1Move);
        }
    }
}