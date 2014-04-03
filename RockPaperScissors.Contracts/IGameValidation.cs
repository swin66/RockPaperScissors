namespace RockPaperScissors.Contracts
{
    public interface IGameValidation
    {
        bool IsValidGameType(string gameTypeName);
        bool IsValidMoveName(string moveName);
        bool IsValidPlayerType(string playerTypeName);

    }
}
