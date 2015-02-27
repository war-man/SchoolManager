using SchoolManager.Entities;
using SchoolManager.Infrastructure;
using SchoolManager.Services.Download;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManager.Services.Data;

namespace SchoolManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Injector.SetupContainer();
            var schoolDownloader = Injector.Container.GetInstance<ISchoolDownloader>();
            var dataTableBuilder = Injector.Container.GetInstance<IDataTableBuilder>();

            Task.Run(async () =>
                {

                    var students = await schoolDownloader.GetStudentsAsync();
                    var teachers = await schoolDownloader.GetTeachersAsync();

                    var teachersWithStudents = teachers
                        .Select(teacherWithClasses =>
                            new
                             {
                                 Teacher = teacherWithClasses,
                                 Students = students
                                     .Where(studentWithClasses => studentWithClasses.Classes.Any(teacherWithClasses.Classes.Contains))
                                     .ToList()
                             }).ToList();

                    List<Tuple<Teacher, IList<Student>>> groups =
                        teachersWithStudents.Select(h => new Tuple<Teacher, IList<Student>>(h.Teacher, h.Students)).ToList();

                    var dt = dataTableBuilder.BuildDataTable(groups);

                }).Wait();
        }
    }
}
