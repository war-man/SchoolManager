using SchoolManager.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Data
{
    class DataTableBuilder : SchoolManager.Services.Data.IDataTableBuilder
    {
        public DataTable BuildDataTable(IList<Tuple<Teacher, IList<Student>>> teachersWithStudents)
        {
            var dt = new DataTable();

            for (int ii = 0; ii < teachersWithStudents.Count; ii++)
            {
                var teacherWithStudents = teachersWithStudents[ii];
                dt.Columns.Add(teacherWithStudents.Item1.Fullname);
                for (int jj = 0; jj < teacherWithStudents.Item2.Count; jj++)
                {
                    dt.Rows.Add();
                    dt.Rows[jj][ii] = teacherWithStudents.Item2[jj].Fullname;
                }
            }

            return dt;
        }
    }
}
