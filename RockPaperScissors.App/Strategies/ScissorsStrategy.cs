using RockPaperScissors.Contracts;

namespace RockPaperScissors.App.Strategies
{
    public class ScissorsStrategy : IMoveStrategy
    {
        public StrategyResult CalculateResult(IMoveStrategy opponentsStrategy)
        {
            if (opponentsStrategy is PaperStrategy) return StrategyResult.Won;

            if (opponentsStrategy is RockStrategy) return StrategyResult.Lost;

            return StrategyResult.Drawn;
        }
    }
}
