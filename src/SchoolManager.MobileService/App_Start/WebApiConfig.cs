using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using SchoolManager.MobileService.DataObjects;
using SchoolManager.MobileService.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace SchoolManager.MobileService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = Guid.NewGuid().ToString(), Fullname = "Pablo Iglesias", BirthDay = DateTime.Now.AddYears(-40) },
                new Student { Id = Guid.NewGuid().ToString(), Fullname = "Francisco Jose", BirthDay = DateTime.Now.AddYears(-50) },
            };

            IList<Teacher> teachers = new List<Teacher>
            {
                new Teacher { Id = Guid.NewGuid().ToString(), Fullname = "Professor X"},
                new Teacher { Id = Guid.NewGuid().ToString(), Fullname = "Quique Fernandez"},
                new Teacher { Id = Guid.NewGuid().ToString(), Fullname = "Daniel Rozo" }
            };

            foreach (Student student in students)
            {
                context.Set<Student>().Add(student);
            }

            foreach (Teacher teacher in teachers)
            {
                context.Set<Teacher>().Add(teacher);
            }

            base.Seed(context);
        }
    }
}

