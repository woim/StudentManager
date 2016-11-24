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


        public List<Course> Courses
        {
            get
            {
                return m_courses;
            }
        }


        public DataBase(string archiveName)
        {
            m_archiveName = archiveName;
            m_accessor = new Accessor();
            m_courses = m_accessor.Load(m_archiveName);
        }
        
        public void AddClass(string className)
        {
            if( m_courses.Exists( c => c.Name == className) )
            {
                throw new ArgumentException("Error class already exist.");
            }       
            m_courses.Add(new Course(className));
        }

        public void RemoveClass(string className)
        {
            Course courseToRemove = new Course(className); 
            if (!m_courses.Exists(c => c.Name == courseToRemove.Name))
            {
                throw new ArgumentException("Error class do not exist.");
            }
            m_courses.RemoveAll(c => c.Name == courseToRemove.Name);
        }

        public void Save()
        {
            m_accessor.Courses = m_courses;
            m_accessor.Save(m_archiveName);
        }

        public Course SelectCourse(string className)
        {
            return m_courses.Find( c => c.Name == className );
        }
    }
}
