using NUnit.Framework;
//using System;
using ClassLibrary;
using System.Collections.Generic;
//using System.Linq;
using System.IO;

namespace TestUnit
{
	[TestFixture]
	public class AccessorTestClass
	{
        Accessor m_accessor;
        List<Class> m_classesExpected;
        string m_testDataBaseName;

        [SetUp]
        public void createDatabase()
        {
            m_accessor = new Accessor();

            string text = "MAT008/Loiseau,Martin=12.0,13.0,14.0|Thibodeau,Jean=18.0,18.0,18.0";
            m_testDataBaseName = TestContext.CurrentContext.WorkDirectory.ToString() + @"\testableDataBase.txt";
            File.WriteAllText(m_testDataBaseName, text);

            Student student1 = new Student();
            student1.Name = "Loiseau";
            student1.FirstName = "Martin";
            student1.Notes = new List<double> { 12.0, 13.0, 14.0 };

            Student student2 = new Student();
            student2.Name = "Thibodeau";
            student2.FirstName = "Jean";
            student2.Notes = new List<double> { 18.0, 18.0, 18.0 };
            
            Class testableClass = new Class("MAT008");
            testableClass.Students = new List<Student> { student1, student2 };

            m_classesExpected = new List<Class> { testableClass };
        }

		[Test]
		public void ShouldLoadDataBase()
		{
            List<Class> classesActual = m_accessor.Load(m_testDataBaseName);
            Assert.That(classesActual, Is.EquivalentTo(m_classesExpected));
        }
        
        [TearDown]
        public void DisposeDataBase()
        {
            File.Delete(m_testDataBaseName);
        }
	}
}

