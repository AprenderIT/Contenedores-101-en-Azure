using EnvironmentVariables.Sql.Api.Data;

using System;
using System.Threading.Tasks;

namespace EnvironmentVariables.Sql.Api.Services
{
    public interface IWebsiteService
    {
        Task<Website> CreateAsync(Uri websiteUri);
        Task DeleteAsync(Guid id);
    }
}