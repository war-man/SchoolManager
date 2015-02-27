using SchoolManager.Entities;
using System;
using System.Collections.Generic;
using System.Data;
namespace SchoolManager.Services.Data
{
    interface IDataTableBuilder
    {
        DataTable BuildDataTable(IList<Tuple<Teacher, IList<Student>>> teachersWithStudents);
    }
}
