using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.MobileService.DataObjects
{
    public class Teacher : EntityData
    {
        public string Fullname { get; set; }

        public DateTime BirthDay { get; set; }

        public decimal Salary { get; set; }

        public string Classes { get; set; }
    }
}