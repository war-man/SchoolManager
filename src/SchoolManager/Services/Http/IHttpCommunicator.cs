using System;
using System.Threading.Tasks;

namespace SchoolManager.Services.Http
{
    interface IHttpCommunicator
    {
        /// <summary>
        /// Copies the stream from the download request uri into a file asynchronously
        /// </summary>
        Task DownloadToFileAsync(string requestUri, string filename);

        /// <summary>
        /// Sends an HTTP GET request to the specified URI.
        /// </summary>
        /// <param name="requestUri">This is the relative URL to be called, DatabaseWebServiceUrl is always appended.</param>
        /// <returns>The task representing the response string</returns>
        /// <exception cref="HttpRequestException"></exception>
        Task<string> SendGetRequestAsync(string requestUri);
    }
}
