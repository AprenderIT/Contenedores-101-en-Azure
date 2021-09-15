using EnvironmentVariables.InMemory.Api.Data;

using System;
using System.Threading.Tasks;

namespace EnvironmentVariables.InMemory.Api.Services
{
    public interface IWebsiteService
    {
        Task<Website> CreateAsync(Uri websiteUri);
        Task DeleteAsync(Guid id);
    }
}