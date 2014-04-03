namespace RockPaperScissors.Contracts
{
    public interface IMoveStrategy
    {
        StrategyResult CalculateResult(IMoveStrategy opponentsStrategy);
    }
}
