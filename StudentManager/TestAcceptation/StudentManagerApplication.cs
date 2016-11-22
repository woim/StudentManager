using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.IO;

namespace TestAcceptation
{
    public class StudentManagerApplication
    {
        private string m_processName;
        private string m_dataBaseName;
        private string m_cmdRoot;
        private List<string> m_listClass;
        private Process m_process;

        public string ErrorMessage { get; private set; }
        public string OutputMessage { get; private set; }
        public List<string> ListClass
        {
            get
            {
                return m_listClass;
            }
        } 

        public StudentManagerApplication()
        {
            m_processName = @"F:\Personnel\Uqam\MGL7460_Realisation\lab\StudentManager\StudentManager\StudentManager\bin\Debug\StudentManager.exe";
            m_dataBaseName = @"C:\temp\testableDataBase.txt";
            m_cmdRoot = "-d=" + m_dataBaseName + " ";
            m_listClass = new List<string>();

            // Creating process and set up
            m_process = new Process();
            m_process.StartInfo.UseShellExecute = false;
            m_process.StartInfo.RedirectStandardError = true;
            m_process.StartInfo.RedirectStandardOutput = true;
            m_process.StartInfo.FileName = m_processName;
        }

        private string CreateDataFromTableRow(TableRow row)
        {
            string data = row["Class"].ToString() + "/";

            return data;
        }

        private void Process(string command)
        {
            m_process.StartInfo.Arguments = m_cmdRoot + command;
            m_process.Start();
            ErrorMessage = m_process.StandardError.ReadToEnd();
            OutputMessage = m_process.StandardOutput.ReadToEnd();
            ReadTestableDataBase();
        }

        private string GetClass(string entry)
        {
            return entry.Split('/')[0];            
        }

        private void ReadTestableDataBase()
        {
            foreach (var entry in File.ReadAllLines(m_dataBaseName))
            {
                m_listClass.Add(GetClass(entry));
            }
        }

        public void CreateTestableDataBase(Table table)
        {
            // Create testable data base
            List<string> data = new List<string>();
            foreach (var row in table.Rows)
            {
                data.Add(CreateDataFromTableRow(row));
            }
            // Write the data in the testable data base
            File.WriteAllLines(m_dataBaseName, data);            
        }
         
        public void AddClass(string className)
        {
            string command = "--addClass=" + className;
            Process(command);
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