using System;
using System.Linq;
using NUnit.Framework;
using RockPaperScissors.AcceptanceTests.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RockPaperScissors.AcceptanceTests.FeatureSteps
{
    [Binding]
    public class GeneratedMoveSteps
    {
        private readonly AppContext _appContext;

        public GeneratedMoveSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [When(@"I get a generated move")]
        public void WhenIGetAGeneratedMove()
        {
            _appContext.Get("game/moves/random");
        }

        [Then(@"The move is one of the following valid move names")]
        public void ThenTheIsOneOfTheFollowingValidMoveNames(Table table)
        {
            var moveName = _appContext.GetTypedContent<string>();
            var found = table.Rows.Any(m => m.Values.Contains(moveName));
            Assert.IsTrue(found, "Generated move not valid");
        }
    }
}
