using System;
using FakeItEasy;
using NUnit.Framework;
using RockPaperScissors.App;
using RockPaperScissors.Contracts;

namespace RockPaperScissors.UnitTests
{
    [TestFixture]
    public class GameEngineTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "player1MoveName")]
        public void CalculateWinnerWithInvalidPlayer1MoveTest()
        {
            var appRepository = A.Fake<IAppRepository>();
            var gameValidation = A.Fake<IGameValidation>();
            string player1Move = null;
            A.CallTo(() => gameValidation.IsValidMoveName(player1Move)).Returns(false);
            var sut = new GameEngine(appRepository, gameValidation);

             sut.CalculateWinner(player1Move, "rock");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "player2MoveName")]
        public void CalculateWinnerWithInvalidPlayer2MoveTest()
        {
            var appRepository = A.Fake<IAppRepository>();
            var gameValidation = A.Fake<IGameValidation>();
            var player1Move = "rock";
            string player2Move = null;
            A.CallTo(() => gameValidation.IsValidMoveName(player1Move)).Returns(true);
            A.CallTo(() => gameValidation.IsValidMoveName(player2Move)).Returns(false);

            var sut = new GameEngine(appRepository, gameValidation);

            sut.CalculateWinner(player1Move, player2Move);
        }
    }
}
