using System;
namespace SchoolManager.Services.Data
{
    interface IExcelPackageCreator
    {
        void CreateAndSaveExcelPackage(System.Data.DataTable originDataTable);
    }
}
