using System.Net;
using NUnit.Framework;
using RockPaperScissors.AcceptanceTests.Helpers;
using RockPaperScissors.Web.Models;
using TechTalk.SpecFlow;

namespace RockPaperScissors.AcceptanceTests.FeatureSteps
{
    [Binding]
    public class GameSteps
    {
        private readonly AppContext _appContext;
        private PlayerMoveModel _player1;
        private PlayerMoveModel _player2;

        public GameSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"I have player1 who is a ""(.*)"" and plays ""(.*)"" move")]
        public void GivenIHavePlayer1WhoIsAAndPlaysMove(string playerType, string moveName)
        {
            _player1 = new PlayerMoveModel{ PlayerType = playerType, MoveName = moveName };
        }

        [Given(@"player2 who is a ""(.*)"" and plays ""(.*)"" move")]
        public void GivenPlayer2WhoIsAAndPlaysMove(string playerType, string moveName)
        {
            _player2 = new PlayerMoveModel { PlayerType = playerType, MoveName = moveName };
        }

        [When(@"I play the game")]
        public void WhenIPlayTheGame()
        {
            var game = new GameModel {Player1Move = _player1, Player2Move = _player2};
            _appContext.Post("game", game);
        }

        [Then(@"the winning player should be (.*)")]
        public void ThenTheWinningPlayerShouldBe(int winningPlayerNumber)
        {
            var gameResult = _appContext.GetTypedContent<GameResultModel>();
            Assert.AreEqual(winningPlayerNumber, gameResult.WinningPlayerNumber);
        }

        [Then(@"the response should be a bad request")]
        public void ThenTheResponseShouldBeABadRequest()
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, _appContext.LastResponse.StatusCode);
        }

    }
}
