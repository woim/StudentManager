using System.Diagnostics;
using TechTalk.SpecFlow;

namespace TestAcceptation
{
    public class StudentManagerApplication
    {
        private string m_applicationName;
        private Process m_application;
                
        public StudentManagerApplication()
        {
            m_applicationName = "";
            m_application = new Process();
            m_application.StartInfo.FileName = m_applicationName;
        }

        public void AddClass(string className)
        {
            string cmd = "-f fakeDB --addCalss=" + className;
            m_application.StartInfo.Arguments = cmd;
            m_application.Start();
        }
    }

    public static class Application
    {
        private const string Key = "application";

        public static StudentManagerApplication Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(Key))
                {
                    ScenarioContext.Current[Key] = new StudentManagerApplication();
                }
                return ScenarioContext.Current[Key] as StudentManagerApplication;
            }           
        }
    }
}