using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class DataBase
    {
        string m_archiveName;
        Accessor m_accessor;
        List<Course> m_courses;
                
        public DataBase(string archiveName)
        {
            m_archiveName = archiveName;
            m_accessor = new Accessor();
            m_courses = m_accessor.Load(m_archiveName);
        }

        public List<Course> Courses
        {
            get
            {
                return m_courses;
            }
        }

        public void AddClass(string className)
        {
            foreach (var course in m_courses)
            {
                if (course.Name == className)
                {
                    throw new ArgumentException("Error class already exist.");
                }
            }            
            m_courses.Add(new Course(className));
        }

        public void Save()
        {
            m_accessor.Courses = m_courses;
            m_accessor.Save(m_archiveName);
        }
    }
}
