using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class DataBase
    {
        Accessor m_accessor;
        List<Class> m_classes;

        public DataBase(string archiveName)
        {
            m_classes = m_accessor.Load(archiveName);
        }

        public void AddClass(string className)
        {
            m_classes.Add(new Class(className));
        }
    }
}
