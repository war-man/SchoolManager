using System;
namespace SchoolManager.Infrastructure
{
    interface IConfiguration
    {
        string StudentsDownloadUrl { get; }
        string TeachersDownloadUrl { get; }
    }
}
