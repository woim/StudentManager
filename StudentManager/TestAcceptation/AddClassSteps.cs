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

        [Then(@"the database should have Two classes ""(.*)"" and ""(.*)""")]
        public void ThenTheDatabaseShouldHaveTwoClassesAnd(string className1, string className2)
        {
            List<string> listClassExpected = new List<string>();
            listClassExpected.Add(className1);
            listClassExpected.Add(className2);
            listClassExpected.Sort();

            List<string> listClassActual = Application.Current.ListClass;
            listClassActual.Sort();

            Assert.That(listClassExpected, Is.EquivalentTo(listClassActual));
        }

        [Then(@"I should get an error message ""(.*)""")]
        public void ThenIShouldGetAnErrorMessage(string errorMessageExpected)
        {
            string errorMessageActual = Application.Current.OutputMessage;
            Assert.That(errorMessageActual, Is.EqualTo(errorMessageExpected));
        }
    }
}
