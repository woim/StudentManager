using NUnit.Framework;
using ClassLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;

namespace TestUnit
{
	[TestFixture]
	public class AccessorTestClass
	{
        Accessor m_accessor;
        List<Course> m_classesExpected;
        string m_testDataBaseName;
        string m_data;

        [SetUp]
        public void Init()
        {
            m_accessor = new Accessor();
            m_classesExpected = new List<Course>();

            m_data = "MAT008/Loiseau,Martin=12,13,14|Thibodeau,Jean=18,18,18";
            m_testDataBaseName = TestContext.CurrentContext.WorkDirectory.ToString() + @"\testableDataBase.txt";
 
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

            m_classesExpected.Add(testableClass);
        }

		[Test]
		public void ShouldLoadDataBase()
		{
            File.WriteAllText(m_testDataBaseName, m_data);
            List<Course> classesActual = m_accessor.Load(m_testDataBaseName);
            classesActual.ShouldBeEquivalentTo(m_classesExpected);
        }

        [Test]
        public void ShouldSaveDataBase()
        {
            m_accessor.Courses = m_classesExpected;
            m_accessor.Save(m_testDataBaseName);
            string data = File.ReadAllText(m_testDataBaseName).Trim();
            Assert.That(data, Is.EqualTo(m_data));
        }
        
        [TearDown]
        public void DisposeDataBase()
        {
            File.Delete(m_testDataBaseName);
        }
	}
}

