using Newtonsoft.Json;
using SchoolManager.Entities;
using SchoolManager.Infrastructure;
using SchoolManager.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Download
{
    class PersonDownloader
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpCommunicator _httpCommunicator;

        public PersonDownloader(IConfiguration configuration, IHttpCommunicator httpCommunicator)
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
    }
}
