using NUnit.Framework;
using System;
using ClassLibrary;
using System.Collections.Generic;


namespace TestUnit
{
	[TestFixture]
	public class AccessorTestClass
	{
        Accessor m_accessor;
        List<Class> m_classesExpected;

        [SetUp]
        public void createDatabase()
        {

            "MAT008/Loiseau,Martin=12.0,13.0,14.0|Thibodeau,Jean,Charles-Henri=18.0,18.0,18.0";
            "BIO012/Thibodeau,Jean,Charles-Henri=17.0,13.0,15.0|Loiseau,Martin=17.0,19.0,15.0";
            System.IO.File.WriteAllLines(m_dataBaseName, data);            
        }

		[Test]
		public void LoadTestCase()
		{
            List<Class> classesActual = m_accessor.Load(testDataBaseName);
            Assert.That(m_classesExpected.SequenceEqual(classesActual));
        }
	}
}

