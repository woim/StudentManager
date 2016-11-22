//using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassLibrary
{
    public class Accessor
    {
        public List<Course> Courses { get; set; }

        public List<Course> Load(string archiveName)
        {
            if (!File.Exists(archiveName))
            {
                string message = "File " + archiveName + " do not exists.";
                throw new FileNotFoundException(message);
            }

            List<Course> Courses = new List<Course>();
            string[] lines = System.IO.File.ReadAllLines(archiveName);
            foreach (var line in lines)
            {
                string[] fields = line.Split('/');                
                Course classLoaded = new Course(fields[0]);

                if(!String.IsNullOrEmpty(fields[1]))
                {
                    string[] students = fields[1].Split('|');
                    foreach (var studentEntry in students)
                    {
                        string[] sutdentInfo = studentEntry.Split('=');
                        List<string> stringNotes = new List<string>(sutdentInfo[1].Split(','));

                        Student student = new Student();
                        student.Name = sutdentInfo[0].Split(',')[0];
                        student.FirstName = sutdentInfo[0].Split(',')[1];
                        student.Notes = stringNotes.Select(x => double.Parse(x)).ToList();

                        classLoaded.AddStudent(student);
                    }                    
                }
                Courses.Add(classLoaded);
            }
            return Courses;
        }

        public void Save(string m_testDataBaseName)
        {
            List<string> entries = new List<string>();
            foreach (var course in Courses)
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