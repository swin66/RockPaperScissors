namespace RockPaperScissors.App.GameTypes
{
    public interface IGameType
    {
        PlayerType Player1 { get; }
        PlayerType Player2 { get; }
    }
}
