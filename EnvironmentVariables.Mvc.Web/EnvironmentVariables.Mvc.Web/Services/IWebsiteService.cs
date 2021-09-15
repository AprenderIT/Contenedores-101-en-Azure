using EnvironmentVariables.Mvc.Web.Data;

using System;
using System.Threading.Tasks;

namespace EnvironmentVariables.Mvc.Web.Services
{
    public interface IWebsiteService
    {
        Task<Website> CreateAsync(Uri websiteUri);
        Task DeleteAsync(Guid id);
    }
}