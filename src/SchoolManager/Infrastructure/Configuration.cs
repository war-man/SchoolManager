using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SchoolManager.Infrastructure
{
    class Configuration : SchoolManager.Infrastructure.IConfiguration
    {
        public string StudentsDownloadUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["StudentsDownloadUrl"];
            }
        }
        public string TeachersDownloadUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["TeachersDownloadUrl"];
            }
        }
    }
}
