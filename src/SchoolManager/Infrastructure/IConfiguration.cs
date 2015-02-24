using System;
namespace SchoolManager.Infrastructure
{
    interface IConfiguration
    {
        string MobileServiceApiBaseAddress { get; }
        string MobileServiceToken { get; }
        string StudentsDownloadUrl { get; }
        string TeachersDownloadUrl { get; }
    }
}
