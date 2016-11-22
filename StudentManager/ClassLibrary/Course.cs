using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Course
    {
        private string m_className;
        private List<Student> m_listStudents;

        public Course(string className)
        {
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