using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Entities
{
    class Person
    {
        public string Id { get; set; }

        public string Fullname { get; set; }

        public DateTime? BirthDay { get; set; }

        public string[] Classes { get; set; }
    }
}
