using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Class
    {
        private string className;

        public Class(string className)
        {
            this.className = className;
        }

        public List<Student> Students { get; set; }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}