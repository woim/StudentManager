using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Student
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public List<double> Notes { get; set; }

        public Student()
        {

        }

        // override object.Equals
        //public override bool Equals(object obj)
        //{
        //    //       
        //    // See the full list of guidelines at
        //    //   http://go.microsoft.com/fwlink/?LinkID=85237  
        //    // and also the guidance for operator== at
        //    //   http://go.microsoft.com/fwlink/?LinkId=85238
        //    //

        //    if (obj == null || GetType() != obj.GetType())
        //    {
        //        return false;
        //    }

        //    // TODO: write your implementation of Equals() here
        //    Student student = (Student)obj;
        //    bool equality = ( Name == student.Name &&
        //                      FirstName == student.FirstName &&
        //                      Notes == student.Notes);
            
        //    return equality;
        //}     
    }
}
