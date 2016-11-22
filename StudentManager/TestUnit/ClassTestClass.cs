using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using ClassLibrary;
using System.Collections.Generic;

namespace TestUnit
{
    [TestFixture]
    public class ClassTestClass
    {
        [Test]
        public void ShouldAddAStudent()
        {
            Class newClass = new Class("MAT001");
            Student student = new Student();
            student.Name = "Robert";
            student.FirstName = "Jean";
            student.Notes = new List<double> { 12.0, 15.0 };             

            newClass.AddStudent(student);
            List<Student> listStudentExpected = new List<Student> { student };

            // TODO: Add your test code here
            Assert.That(newClass.Students, Is.EquivalentTo(listStudentExpected));
        }
    }
}
