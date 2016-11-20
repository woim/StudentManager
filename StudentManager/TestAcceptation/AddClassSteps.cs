using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace TestAcceptation
{
    [Binding]
    public class AddClassSteps
    {
        [Given(@"I have the data base with")]
        public void GivenIHaveTheDataBaseWith(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add the class ""(.*)"" in the data base")]
        public void WhenIAddTheClassInTheDataBase(string className)
        {
            Application.Current.AddClass(className);
        }
          
        [Then(@"the modified database should have classes ""(.*)"" and ""(.*)""")]
        public void ThenTheModifiedDatabaseShouldHaveClassesAnd(string p0, string p1)
        {

        }
        
        [Then(@"I should get on the screen the error message ""(.*)""")]
        public void ThenIShouldGetOnTheScreenTheErrorMessage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
