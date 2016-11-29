using TechTalk.SpecFlow;

namespace TestAcceptation
{
    [Binding]
    public sealed class GenerateDataBaseStep
    {
        [Given(@"I have the data base with")]
        public void GivenIHaveTheDataBaseWith(Table table)
        {
            Application.Current.CreateTestableDataBase(table);
        }
    }
}
