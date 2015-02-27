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

                    var teachersWithClasses =
                        teachers
                        .Select(teacher =>
                            new
                            {
                                Person = teacher,
                                Classes = teacher.Classes.Split(',')
                            });

                    var studentsWithClasses =
                        students
                        .Select(student =>
                            new
                            {
                                Person = student,
                                Classes = student.Classes.Split(',')
                            });

                    var teachersWithStudents = teachersWithClasses
                        .Select(teacherWithClasses =>
                            new
                            {
                                Teacher = teacherWithClasses.Person,
                                Students = studentsWithClasses
                                    .Where(studentWithClasses => studentWithClasses.Classes.Any(teacherWithClasses.Classes.Contains))
                                    .Select(g => g.Person).ToList()
                            }).ToList();

                    List<Tuple<Teacher, IList<Student>>> groups = 
                        teachersWithStudents.Select(h => new Tuple<Teacher, IList<Student>> (h.Teacher, h.Students)).ToList();

                    var dt = dataTableBuilder.BuildDataTable(groups);
                   
                }).Wait();
        }
    }
}
