using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestAcceptation
{
    [Binding]
    public class AddClassSteps
    {
        [When(@"I add the class ""(.*)"" in the data base")]
        public void WhenIAddTheClassInTheDataBase(string className)
        {
            Application.Current.AddClass(className);
        }

        [Then(@"I should get an error message ""(.*)""")]
        public void ThenIShouldGetAnErrorMessage(string errorMessageExpected)
        {
            string errorMessageActual = Application.Current.OutputMessage;
            Assert.That(errorMessageActual, Is.EqualTo(errorMessageExpected));
        }
    }
}
