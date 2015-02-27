using Newtonsoft.Json;
using SchoolManager.Entities;
using SchoolManager.Infrastructure;
using SchoolManager.Services.Download.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SchoolManager.Services.Download
{
    class SchoolDownloader : ISchoolDownloader
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpCommunicator _httpCommunicator;

        public SchoolDownloader(IConfiguration configuration, IHttpCommunicator httpCommunicator)
        {
            _configuration = configuration;
            _httpCommunicator = httpCommunicator;
        }

        public async Task<IList<Student>> GetStudentsAsync()
        {
            string jsonResponse = await _httpCommunicator.SendGetRequestAsync(_configuration.StudentsDownloadUrl);

            IList<Person> students = JsonConvert.DeserializeObject<IList<Person>>(jsonResponse, new JsonConverter[] { new PersonJsonConverter() });

            return students.Select(p => new Student
            {
                Id = p.Id,
                BirthDay = p.BirthDay,
                Classes = p.Classes,
                Fullname = p.Fullname
            }).ToList();
        }

        public async Task<IList<Teacher>> GetTeachersAsync()
        {
            string jsonResponse = await _httpCommunicator.SendGetRequestAsync(_configuration.TeachersDownloadUrl);

            IList<Person> teachers = JsonConvert.DeserializeObject<IList<Person>>(jsonResponse, new JsonConverter[] { new PersonJsonConverter() });

            return teachers.Select(p => new Teacher
            {
                Id = p.Id,
                BirthDay = p.BirthDay,
                Classes = p.Classes,
                Fullname = p.Fullname
            }).ToList();
        }
    }
}
