using SchoolManager.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SchoolManager.Services.Download
{
    interface ISchoolDownloader
    {
        Task<IList<Student>> GetStudentsAsync();
        Task<IList<Teacher>> GetTeachersAsync();
    }
}
