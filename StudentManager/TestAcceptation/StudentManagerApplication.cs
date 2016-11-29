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


        public string OutputMessage { get; private set; }


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
        
        public void AddClass(string className)
        {
            string command = "--addClass=" + className;
            Process(command);
        }

        public void AddStudent(Table table)
        {
            foreach (var row in table.Rows)
            {
                string command = "--class=" + row["Class"] + " --addStudent=" + row["Student"];
                Process(command);
            }
        }

        public void CreateTestableDataBase(Table table)
        {
            // Create testable data base
            List<string> data = new List<string>();
            string className = null;
            foreach (var row in table.Rows)
            {                
                if (className != row["Class"].ToString())
                {
                    string dataString = row["Class"].ToString() + "/";
                    data.Add(dataString);
                    className = row["Class"].ToString();
                }
                else
                {
                    data[data.Count - 1] += "|";
                }

                if (row.Keys.Contains("Student"))
                {
                    data[data.Count - 1] += row["Student"].ToString();
                }              
            }
            // Write the data in the testable data base
            File.WriteAllLines(m_dataBaseName, data);
        }

        public List<Entry> GetDataBase()
        {
            List<Entry> dataBaseEntries = new List<Entry>();
            foreach (var entry in File.ReadAllLines(m_dataBaseName))
            {
                dataBaseEntries.AddRange(FormatLineToEntry(entry));
            }
            return dataBaseEntries;
        }

        public void RemoveClass(string className)
        {
            string command = "--removeClass=" + className;
            Process(command);
        }

        public void RemoveStudent(Table table)
        {
            foreach (var row in table.Rows)
            {
                string command = "--class=" + row["Class"] + " --removeStudent=" + row["Student"];
                Process(command);
            }
        }

        private List<Entry> FormatLineToEntry(string entryLine)
        {
            List<Entry> entries = new List<Entry>();
            
            string[] entryField = entryLine.Split('/');
            string className = entryField[0];
            
            if (entryField.Length > 1)
            {
                string[] listStudent = entryField[1].Split('|');
                foreach (var studentInfo in listStudent)
                {
                    string[] studentField = studentInfo.Split('=');
                    string studentNames = studentField[0]; 

                    Entry entry = new Entry();
                    entry.Class = className;
                    entry.Student = studentNames;
                    entries.Add(entry);
                }
            }
            else
            {
                Entry entry = new Entry();
                entry.Class = className;
                entries.Add(entry);
            }
            return entries;
        }
        
        private void Process(string command)
        {
            m_process.StartInfo.Arguments = m_cmdRoot + command;
            m_process.Start();
            OutputMessage = m_process.StandardOutput.ReadToEnd();
            //ReadTestableDataBase();
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