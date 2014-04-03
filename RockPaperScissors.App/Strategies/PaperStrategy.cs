using RockPaperScissors.Contracts;

namespace RockPaperScissors.App.Strategies
{
    public class PaperStrategy : IMoveStrategy
    {
        public StrategyResult CalculateResult(IMoveStrategy opponentsStrategy)
        {
            if (opponentsStrategy is RockStrategy) return StrategyResult.Won;

            if (opponentsStrategy is ScissorsStrategy) return StrategyResult.Lost;

            return StrategyResult.Drawn;
        }
    }
}
