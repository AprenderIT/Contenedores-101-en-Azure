using C101A.InMemory.Api.Data;
using C101A.InMemory.Api.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C101A.InMemory.Api.Services
{
    public interface IProfileService
    {
        Task<Profile> CreateAsync(CreateProfileModel profileModel);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(Guid id);
    }
}