using Newtonsoft.Json;
using SchoolManager.Entities;
using SchoolManager.Infrastructure;
using SchoolManager.Services.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            IList<Student> students = JsonConvert.DeserializeObject<IList<Student>>(jsonResponse);

            return students;
        }

        public async Task<IList<Teacher>> GetTeachersAsync()
        {
            string jsonResponse = await _httpCommunicator.SendGetRequestAsync(_configuration.TeachersDownloadUrl);

            IList<Teacher> teachers = JsonConvert.DeserializeObject<IList<Teacher>>(jsonResponse);

            return teachers;
        }
    }
}
