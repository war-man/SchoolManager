using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using SchoolManager.Infrastructure;
using Newtonsoft.Json;

namespace SchoolManager.Services.Download.Http
{
    internal class HttpCommunicator : IHttpCommunicator
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClientHandler _httpClientHandler;
        private readonly IConfiguration _configuration;

        protected string BaseUrl { get; set; }

        public HttpCommunicator(IConfiguration configuration)
        {
            if (_httpClient == null)
            {
                _configuration = configuration;

                _httpClientHandler = new HttpClientHandler();
                _httpClient = new HttpClient(_httpClientHandler)
                {
                    Timeout = new TimeSpan(0, 0, 5, 0),
                };

                _httpClient.BaseAddress = new Uri(_configuration.MobileServiceApiBaseAddress, UriKind.Absolute);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-ZUMO-APPLICATION", _configuration.MobileServiceToken);
            }
        }

        /// <summary>
        /// Sends an HTTP GET request to the specified URI.
        /// </summary>
        /// <param name="requestUri">This is the relative URL to be called, DatabaseWebServiceUrl is always appended.</param>
        /// <returns>The task representing the response string</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<string> SendGetRequestAsync(string requestUri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Copies the stream from the download request uri into a file asynchronously
        /// </summary>
        public async Task DownloadToFileAsync(string requestUri, string filename)
        {
            if (requestUri == null || filename == null)
            {
                throw new ArgumentException("Neither the request url or the filename can be null");
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                using (
                    Stream contentStream = await (await _httpClient.SendAsync(request)).Content.ReadAsStreamAsync(),
                    stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, 2 << 18, true))
                {
                    await contentStream.CopyToAsync(stream);
                }
            }
        }

        public async Task<string> SendPostRequestAsync<T>(string uri, T data)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = await _httpClient.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
