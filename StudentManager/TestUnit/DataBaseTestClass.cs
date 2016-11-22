using NUnit.Framework;
using System.Collections.Generic;
using ClassLibrary;
using System.IO;
using FluentAssertions;

namespace TestUnit
{
    [TestFixture]
    public class DataBaseTestClass
    {
        DataBase m_dataBase;
        List<Course> m_classesExpected;
        Course m_testableClass;
        string m_testDataBaseName;
        string m_data;

        [SetUp]
        public void Init()
        {
            Student student1 = new Student();
            student1.Name = "Loiseau";
            student1.FirstName = "Martin";
            student1.Notes = new List<double> { 12.0, 13.0, 14.0 };
            Student student2 = new Student();
            student2.Name = "Thibodeau";
            student2.FirstName = "Jean";
            student2.Notes = new List<double> { 18.0, 18.0, 18.0 };

            m_testableClass = new Course("MAT008");
            m_testableClass.AddStudent(student1);
            m_testableClass.AddStudent(student2);
                        
            m_classesExpected = new List<Course>();
            m_classesExpected.Add(m_testableClass);

            m_data = "MAT008/Loiseau,Martin=12,13,14|Thibodeau,Jean=18,18,18";
            m_testDataBaseName = TestContext.CurrentContext.WorkDirectory.ToString() + @"\testableDataBase.txt";
            File.WriteAllText(m_testDataBaseName, m_data);
            m_dataBase = new DataBase(m_testDataBaseName);
        }

        [Test]
        public void ShouldInstanciateDataBase()
        {
            m_dataBase.Courses.ShouldBeEquivalentTo(m_classesExpected);
        }

        [Test]
        public void ShouldAddAClassToDataBase()
        {
            m_dataBase.AddClass("CHI001");
            m_classesExpected.Add(new Course("CHI001"));
            m_dataBase.Courses.ShouldBeEquivalentTo(m_classesExpected);
        }

        [Test]
        public void ShouldThrowExceptionWhenAddClassThatAlreadyExist()
        {
            m_dataBase.AddClass("CHI001");
            Assert.That(() => m_dataBase.AddClass("CHI001"), Throws.Exception);
        }

        [Test]
        public void ShouldRemoveAClass()
        {
            m_dataBase.RemoveClass("MAT008");
            m_classesExpected = new List<Course>();
            m_dataBase.Courses.ShouldBeEquivalentTo(m_classesExpected);
        }
        
        [TearDown]
        public void DisposeDataBase()
        {
            File.Delete(m_testDataBaseName);
        }
    }
}
