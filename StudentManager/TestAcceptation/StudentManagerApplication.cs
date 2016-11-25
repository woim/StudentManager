using System.Diagnostics;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.IO;
using System;

namespace TestAcceptation
{
    public class StudentManagerApplication
    {
        private string m_processName;
        private string m_dataBaseName;
        private string m_cmdRoot;

        internal void RemoveStudent(Table table)
        {
            throw new NotImplementedException();
        }

        private List<string> m_listClass;
        private Process m_process;


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
            m_processName = @"D:\Utilisateurs\fe891094\Documents\StudentManager\StudentManager\StudentManager\bin\Debug\StudentManager.exe";
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
            foreach (var row in table.Rows)
            {
                data.Add(CreateDataFromTableRow(row));
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



        private string CreateDataFromTableRow(TableRow row)
        {
            string data = row["Class"].ToString() + "/";
            if (row.Keys.Contains("Student"))
            {
                data += row["Student"].ToString();
            }
            return data;
        }

        private List<Entry> FormatLineToEntry(string entryLine)
        {
            List<Entry> entries = new List<Entry>();
            
            string className = entryLine.Split('/')[0];
            string classInfo = entryLine.Split('/')[1];

            if (!String.IsNullOrEmpty(classInfo))
            {
                string[] listStudent = classInfo.Split('|');
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

        private string GetClass(string entry)
        {
            return entry.Split('/')[0];
        }
        
        private void Process(string command)
        {
            m_process.StartInfo.Arguments = m_cmdRoot + command;
            m_process.Start();
            OutputMessage = m_process.StandardOutput.ReadToEnd();
            ReadTestableDataBase();
        }

        private void ReadTestableDataBase()
        {
            foreach (var entry in File.ReadAllLines(m_dataBaseName))
            {
                m_listClass.Add(GetClass(entry));
            }
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