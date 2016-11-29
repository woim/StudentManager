using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestAcceptation
{
    [Binding]
    public sealed class VerifyDataBase
    {
        [Then(@"the data base should have those element")]
        public void ThenTheDataBaseShouldHaveThoseElement(Table table)
        {
            var dataBaseEntries = Application.Current.GetDataBase();
            table.CompareToSet<Entry>(dataBaseEntries);
        }
    }
}
