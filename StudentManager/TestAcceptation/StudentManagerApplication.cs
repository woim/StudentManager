﻿using System.Diagnostics;
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
                string command = "--class=" + row["Class"] + "--addStudent = " + row["Student"];
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
            return dataBaseEntries;
        }


        private string CreateDataFromTableRow(TableRow row)
        {
            string data = row["Class"].ToString() + "/";

            return data;
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

        public void RemoveClass(string className)
        {
            string command = "--removeClass=" + className;
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