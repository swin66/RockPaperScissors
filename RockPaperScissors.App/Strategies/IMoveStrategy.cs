namespace RockPaperScissors.App.Strategies
{
    public interface IMoveStrategy
    {
        StrategyResult CalculateResult(IMoveStrategy opponentsStrategy);
    }
}
