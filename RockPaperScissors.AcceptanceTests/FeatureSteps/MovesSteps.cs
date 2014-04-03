using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RockPaperScissors.AcceptanceTests.Helpers;
using TechTalk.SpecFlow;

namespace RockPaperScissors.AcceptanceTests.FeatureSteps
{
    [Binding]
    public class MovesSteps
    {
        private readonly AppContext _appContext;
        private string _moveName;

        public MovesSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"I have a move name of (.*)")]
        public void GivenIHaveAMoveNameOf(string p0)
        {
            _moveName = p0;
        }

        //[Given(@"I have a move name of (.*)")]
        //public void GivenIHaveAMoveNameOf(string moveName)
        //{
        //    _moveName = moveName;
        //}

        [When(@"I get the list of available move names")]
        public void WhenIGetTheListOfAvailableMoveNames()
        {
            _appContext.Get("game/moves");
        }

        [Then(@"the move name should be allowed")]
        public void ThenTheMoveNameShouldBeAllowed()
        {
            var found = FindMoveName();
            Assert.IsTrue(found, "Move name not found");
        }

        [Then(@"the move name should not be allowed")]
        public void ThenTheMoveNameShouldNotBeAllowed()
        {
            var found = FindMoveName();
            Assert.IsFalse(found, "Move name found");
        }

        private bool FindMoveName()
        {
            var moveNames = _appContext.GetTypedContent<IEnumerable<string>>();
            var found = moveNames.Any(g => g.Equals(_moveName, StringComparison.OrdinalIgnoreCase));
            return found;
        }
    }
}
