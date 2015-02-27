using SchoolManager.Services.Data;
using SchoolManager.Services.Download;
using SchoolManager.Services.Download.Http;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Infrastructure
{
    static class Injector
    {
        public static Container Container { get; private set; }

        public static void SetupContainer()
        {
            var container = new Container();

            container.Register<IHttpCommunicator, HttpCommunicator>();
            container.Register<IConfiguration, Configuration>();
            container.Register<ISchoolDownloader, SchoolDownloader>();
            container.Register<IDataTableBuilder, DataTableBuilder>();
            container.Register<IExcelPackageCreator, ExcelPackageCreator>();

            Container = container;
        }
    }
}
