//using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassLibrary
{
    public class Accessor
    {
        public List<Class> Classes { get; set; }

        public List<Class> Load(string archiveName)
        {
            if (!File.Exists(archiveName))
            {
                string message = "File " + archiveName + " do not exists.";
                throw new FileNotFoundException(message);
            }

            List<Class> Classes = new List<Class>();
            string[] lines = System.IO.File.ReadAllLines(archiveName);
            foreach (var line in lines)
            {
                string className = line.Split('/')[0];
                Class classLoaded = new Class(className);

                string studentsInfo = line.Split('/')[1];
                string[] students = studentsInfo.Split('|');
                foreach(var studentEntry in students)
                {
                    string[] sutdentInfo = studentEntry.Split('=');
                    List<string> stringNotes = new List<string>( sutdentInfo[1].Split(',') );

                    Student student = new Student();
                    student.Name = sutdentInfo[0].Split(',')[0];
                    student.FirstName = sutdentInfo[0].Split(',')[1];
                    student.Notes = stringNotes.Select(x => double.Parse(x)).ToList();

                    classLoaded.AddStudent(student);                    
                }
                Classes.Add(classLoaded);              
            }
            return Classes;
        }

        public void Save(string m_testDataBaseName)
        {
            List<string> entries = new List<string>();
            foreach (var course in Classes)
            {
                string entry = course.Name + "/";
                foreach (var student in course.Students)
                {
                    entry += student.Name + "," + student.FirstName + "=";
                    entry += string.Join(",", student.Notes);
                    if (student != course.Students.Last())
                    {
                        entry += "|";
                    }
                }
                entries.Add(entry);
            }
            File.WriteAllLines(m_testDataBaseName, entries);
        }
    }
}