using RockPaperScissors.Contracts;

namespace RockPaperScissors.App.Strategies
{
    public static class StrategyResultExtensions
    {
        public static int MapToWinningPlayer(this StrategyResult strategyResult)
        {
            return strategyResult == StrategyResult.Drawn
               ? 0
               : strategyResult == StrategyResult.Won
                   ? 1
                   : 2;
        }
    }
}
