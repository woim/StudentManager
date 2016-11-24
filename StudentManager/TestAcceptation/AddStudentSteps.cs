using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestAcceptation
{
    [Binding]
    public class AddStudentSteps
    {
        [When(@"I add a student to the class")]
        public void WhenIAddAStudentToTheClass(Table table)
        {
            Application.Current.AddStudent(table);
        }
        
        [Then(@"the data base should have those element")]
        public void ThenTheDataBaseShouldHaveThoseElement(Table table)
        {
            var dataBaseEntries = Application.Current.GetDataBase();
            table.CompareToSet<Entry>(dataBaseEntries);
        }
    }
}
