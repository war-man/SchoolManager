using SchoolManager.Infrastructure;
using SchoolManager.Services.Download;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Injector.SetupContainer();
            var schoolDownloader = Injector.Container.GetInstance<ISchoolDownloader>();

            var students = schoolDownloader.GetStudentsAsync().Result;
        }
    }
}
