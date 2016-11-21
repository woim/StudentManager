using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Class
    {
        private string className;
        private List<Student> m_listStudents;

        public Class(string className)
        {
            this.className = className;
            m_listStudents = new List<Student>();
        }

        public List<Student> Students
        {
            get
            {
                return m_listStudents;
            }
        }

        public void AddStudent(Student student)
        {
            m_listStudents.Add(student);
        }
    }
}