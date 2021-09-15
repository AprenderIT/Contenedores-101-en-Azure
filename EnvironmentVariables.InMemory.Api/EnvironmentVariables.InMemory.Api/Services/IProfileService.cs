using EnvironmentVariables.InMemory.Api.Data;
using EnvironmentVariables.InMemory.Api.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentVariables.InMemory.Api.Services
{
    public interface IProfileService
    {
        Task<Profile> CreateAsync(CreateProfileModel profileModel);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(Guid id);
    }
}