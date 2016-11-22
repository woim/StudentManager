using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class Course
    {
        private string m_className;
        private List<Student> m_listStudents;

        public Course(string className)
        {
            Regex r = new Regex("[A-Z]{3}[0-9]{3}");
            bool respectPat = r.IsMatch(className);
            if ( !respectPat || className.Length != 6 )
            {
                throw new ArgumentException("Error class name format incorrect.");
            }
            m_className = className;
            m_listStudents = new List<Student>();
        }

        public List<Student> Students
        {
            get
            {
                return m_listStudents;
            }
        }
        public string Name
        {
            get
            {
                return m_className;
            }
        }

        public void AddStudent(Student student)
        {
            m_listStudents.Add(student);
        }
    }
}