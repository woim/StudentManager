using TechTalk.SpecFlow;

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
     }
}
