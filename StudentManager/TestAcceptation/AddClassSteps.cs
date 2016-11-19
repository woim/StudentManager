using System;
using TechTalk.SpecFlow;

namespace TestAcceptation
{
    [Binding]
    public class AddClassSteps
    {
        [Given(@"I have one calss ""(.*)"" in the data base")]
        public void GivenIHaveOneCalssInTheDataBase(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add the class ""(.*)"" in the data base")]
        public void WhenIAddTheClassInTheDataBase(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add a class MA with bad format name")]
        public void WhenIAddAClassMAWithBadFormatName()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the modified database should have classes ""(.*)"" and ""(.*)""")]
        public void ThenTheModifiedDatabaseShouldHaveClassesAnd(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should get on the screen the error message ""(.*)""")]
        public void ThenIShouldGetOnTheScreenTheErrorMessage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
