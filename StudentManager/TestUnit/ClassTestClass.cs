using NUnit.Framework;
using ClassLibrary;
using System.Collections.Generic;


namespace TestUnit
{
    [TestFixture]
    public class ClassTestClass
    {
        Course m_class;
        Student m_student;
        List<Student> m_listStudentExpected;

        [SetUp]
        public void CreationFakeClass()
        {
            m_class = new Course("MAT001");
            m_student = new Student();
            m_student.Name = "Robert";
            m_student.FirstName = "Jean";
            m_student.Notes = new List<double> { 12.0, 15.0 };

            m_class.AddStudent(m_student);            
        }

        [Test]
        public void ShouldAddAStudent()
        {
            m_listStudentExpected = new List<Student> { m_student };
            Assert.That(m_class.Students, Is.EquivalentTo(m_listStudentExpected));
        }

        [TestCase("MA")]
        [TestCase("MAT01")]
        [TestCase("MAT0001")]
        public void ShouldHaveACorrectFormat(string courseName)
        {
            Assert.That(() => new Course(courseName), Throws.Exception);
        }

        [Test]
        public void ShouldRemoveAStudent()
        {
            string studentName = m_student.Name+ "," + m_student.FirstName;
            m_class.RemoveStudent(studentName);
            Assert.That(m_class.Students, Is.Empty);
        }
    }
}
