using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.MobileService.DataObjects
{
    public class Student : EntityData
    {
        public string Fullname { get; set; }
        public DateTime BirthDay { get; set; }
        public IList<string> Classes { get; set; }
        public IList<string> Books { get; set; }
        public int Course { get; set; }
    }
}