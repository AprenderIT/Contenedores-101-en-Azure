using C101A.Mvc.Web.Data;

using System;
using System.Threading.Tasks;

namespace C101A.Mvc.Web.Services
{
    public interface IWebsiteService
    {
        Task<Website> CreateAsync(Uri websiteUri);
        Task DeleteAsync(Guid id);
    }
}