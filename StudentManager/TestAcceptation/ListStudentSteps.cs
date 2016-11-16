using System;
using TechTalk.SpecFlow;

namespace TestAcceptation
{
    [Binding]
    public class ListStudentSteps
    {
        [Given(@"I have a (.*) and (.*) in (.*)")]
        public void GivenIHaveAAndIn(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I run this command ""(.*)""")]
        public void WhenIRunThisCommand(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should get on the screen ""(.*)""")]
        public void ThenIShouldGetOnTheScreen(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
