using TechTalk.SpecFlow;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestAcceptation
{
    [Binding]
    public class RemoveClassSteps
    {
        [When(@"I remove the class ""(.*)"" in the data base")]
        public void WhenIRemoveTheClassInTheDataBase(string className)
        {
            Application.Current.RemoveClass(className);
        }
        
        [Then(@"the modified database should have classes ""(.*)""")]
        public void ThenTheModifiedDatabaseShouldHaveClasses(string className)
        {
            List<string> listClassExpected = new List<string>();
            listClassExpected.Add(className);
            listClassExpected.Sort();

            List<string> listClassActual = Application.Current.ListClass;
            listClassActual.Sort();

            Assert.That(listClassExpected, Is.EquivalentTo(listClassActual));
        }
    }
}
