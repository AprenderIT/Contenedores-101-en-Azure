using C101A.Sql.Api.Data;

using System;
using System.Threading.Tasks;

namespace C101A.Sql.Api.Services
{
    public interface IWebsiteService
    {
        Task<Website> CreateAsync(Uri websiteUri);
        Task DeleteAsync(Guid id);
    }
}