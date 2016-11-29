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

        public void AddStudent(string studentName)
        {
            Student student = GetStudentFromName(studentName);
            if (m_listStudents.Exists(s => s.Name == student.Name && s.FirstName == student.FirstName))
            {
                throw new ArgumentException("Error student already exist.");
            }
            AddStudent(student);
        }

        public void RemoveStudent(string studentName)
        {
            Student student = GetStudentFromName(studentName);
            if (!m_listStudents.Exists(s => s.Name == student.Name && s.FirstName == student.FirstName))
            {
                throw new ArgumentException("Error student do not exist.");
            }
            m_listStudents.RemoveAll(s => s.Name == student.Name && s.FirstName == student.FirstName);
        }

        private Student GetStudentFromName(string studentName)
        {
            string[] names = studentName.Split(',');
            if (names.Length != 2)
            {
                throw new ArgumentException("Student must have name and at least a first name");
            }
            Student student = new Student();
            student.Name = names[0];
            student.FirstName = names[1];
            return student;
        }
    }
}