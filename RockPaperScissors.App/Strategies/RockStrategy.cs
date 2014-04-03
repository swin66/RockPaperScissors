using RockPaperScissors.Contracts;

namespace RockPaperScissors.App.Strategies
{
    public class RockStrategy : IMoveStrategy
    {
        public StrategyResult CalculateResult(IMoveStrategy opponentsStrategy)
        {
            if (opponentsStrategy is ScissorsStrategy) return StrategyResult.Won;

            if (opponentsStrategy is PaperStrategy) return StrategyResult.Lost;

            return StrategyResult.Drawn;
        }
    }
}
