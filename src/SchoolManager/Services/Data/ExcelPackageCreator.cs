using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace SchoolManager.Services.Data
{
    class ExcelPackageCreator : SchoolManager.Services.Data.IExcelPackageCreator
    {
        public void CreateAndSaveExcelPackage(DataTable originDataTable)
        {
            ExcelPackage xlPackage = new ExcelPackage(new FileInfo(Guid.NewGuid().ToString()+".xlsx"));
            xlPackage.Workbook.Worksheets.Add("Sheet1").Cells["A1"].LoadFromDataTable(originDataTable, true);
            xlPackage.Save();
        }
    }
}
