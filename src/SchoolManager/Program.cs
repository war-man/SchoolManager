using SchoolManager.Entities;
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

            Task.Run(async () =>
                {
                    var students = await schoolDownloader.GetStudentsAsync();
                    var teachers = await schoolDownloader.GetTeachersAsync();

                    var teachersWithClasses = 
                        teachers
                        .Select(teacher => 
                            new { 
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

                    var a = teachersWithClasses
                        .Select(teacherWithClasses => 
                            new { 
                                Teacher = teacherWithClasses.Person, 
                                Students = studentsWithClasses
                                    .Where(studentWithClasses => studentWithClasses.Classes.Any(teacherWithClasses.Classes.Contains)).ToList() 
                            }).ToList();
                    Console.Write(a);
                }).Wait();
        }
    }
}
