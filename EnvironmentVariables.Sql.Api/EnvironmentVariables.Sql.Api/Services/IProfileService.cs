using EnvironmentVariables.Sql.Api.Data;
using EnvironmentVariables.Sql.Api.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentVariables.Sql.Api.Services
{
    public interface IProfileService
    {
        Task<Profile> CreateAsync(CreateProfileModel profileModel);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(Guid id);
    }
}