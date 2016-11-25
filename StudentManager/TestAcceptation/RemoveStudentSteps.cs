using System;
using TechTalk.SpecFlow;

namespace TestAcceptation
{
    [Binding]
    public class RemoveStudentSteps
    {
        [When(@"I rermove a student to the class")]
        public void WhenIRermoveAStudentToTheClass(Table table)
        {
            Application.Current.RemoveStudent(table);
        }
    }
}
