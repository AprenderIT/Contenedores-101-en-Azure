using EnvironmentVariables.Mvc.Web.Data;
using EnvironmentVariables.Mvc.Web.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentVariables.Mvc.Web.Services
{
    public interface IProfileService
    {
        Task<Profile> CreateAsync(CreateProfileModel profileModel);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(Guid id);
    }
}