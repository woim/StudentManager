using TechTalk.SpecFlow;

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
    }
}
