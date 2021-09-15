using C101A.Mvc.Web.Data;
using C101A.Mvc.Web.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C101A.Mvc.Web.Services
{
    public interface IProfileService
    {
        Task<Profile> CreateAsync(CreateProfileModel profileModel);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(Guid id);
    }
}