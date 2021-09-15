using C101A.InMemory.Api.Data;

using System;
using System.Threading.Tasks;

namespace C101A.InMemory.Api.Services
{
    public interface IWebsiteService
    {
        Task<Website> CreateAsync(Uri websiteUri);
        Task DeleteAsync(Guid id);
    }
}