using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RockPaperScissors.AcceptanceTests.Helpers;
using RockPaperScissors.Web.Models;
using TechTalk.SpecFlow;

namespace RockPaperScissors.AcceptanceTests.FeatureSteps
{
    [Binding]
    public class GameTypesSteps
    {
        private readonly AppContext _appContext;
        private string _player1;
        private string _player2;

        public GameTypesSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"I have player1 who is a ""(.*)""")]
        public void GivenIHavePlayer1WhoIsA(string player)
        {
            _player1 = player;
        }

        [Given(@"player2 who is a ""(.*)""")]
        public void GivenPlayer2WhoIsA(string player)
        {
            _player2 = player;
        }

        [When(@"I get the list of available game types")]
        public void WhenIGetTheListOfAvailableGameTypes()
        {
            _appContext.Get("game/types");
        }

        [Then(@"the game type should be allowed")]
        public void ThenTheGameTypeShouldBeAllowed()
        {
            var found = FindGameType();
            Assert.IsTrue(found, "Player combination not found");
        }

        [Then(@"the game type should not be allowed")]
        public void ThenTheGameTypeShouldNotBeAllowed()
        {
            var found = FindGameType();
            Assert.IsFalse(found, "Player combination found");
        }

        private bool FindGameType()
        {
            var gameTypes = _appContext.GetTypedContent<IEnumerable<GameTypeModel>>();
            var found = gameTypes.Any(g => g.Player1.Equals(_player1, StringComparison.OrdinalIgnoreCase) 
                                                && g.Player2.Equals(_player2, StringComparison.OrdinalIgnoreCase));
            return found;
        }
    }
}
