using TechTalk.SpecFlow;

namespace TestAcceptation
{
    [Binding]
    public class RemoveStudentSteps
    {
        [When(@"I remove a student to the class")]
        public void WhenIRemoveAStudentToTheClass(Table table)
        {
            Application.Current.RemoveStudent(table);
        }
    }
}
