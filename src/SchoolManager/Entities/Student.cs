using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Entities
{
    class Student : Person
    {
        public override string ToString()
        {
            return "Student: " + this.Fullname;
        }
    }
}
