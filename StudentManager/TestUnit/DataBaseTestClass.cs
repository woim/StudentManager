using NUnit.Framework;
using System.Collections.Generic;
using ClassLibrary;
using System.IO;

namespace TestUnit
{
    [TestFixture]
    public class DataBaseTestClass
    {
        DataBase m_dataBase;
        List<Course> m_classesExpected;
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

            Course testableClass = new Course("MAT008");
            testableClass.AddStudent(student1);
            testableClass.AddStudent(student2);
                        
            m_classesExpected = new List<Course>();
            m_classesExpected.Add(testableClass);

            m_data = "MAT008/Loiseau,Martin=12,13,14|Thibodeau,Jean=18,18,18";
            m_testDataBaseName = TestContext.CurrentContext.WorkDirectory.ToString() + @"\testableDataBase.txt";
            File.WriteAllText(m_testDataBaseName, m_data);
            m_dataBase = new DataBase(m_testDataBaseName);
        }

        [Test]
        public void ShouldInstanciateDataBase()
        {
           Assert.That(m_dataBase.Courses, Is.EquivalentTo(m_classesExpected));
        }

        [Test]
        public void ShouldAddAClass()
        {
            m_dataBase.AddClass("CHI001");
            m_classesExpected.Add(new Course("CHI001"));
            Assert.That(m_dataBase.Courses, Is.EquivalentTo(m_classesExpected));
        }
        
        [TearDown]
        public void DisposeDataBase()
        {
            File.Delete(m_testDataBaseName);
        }
    }
}
