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
        
        [Given(@"I have a ""(.*)"" in the data base")]
        public void GivenIHaveAInTheDataBase(string p0)
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
        
        [Then(@"the modified database should have (.*) classes ""(.*)"" ""(.*)""")]
        public void ThenTheModifiedDatabaseShouldHaveClasses(int p0, string p1, string p2)
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
