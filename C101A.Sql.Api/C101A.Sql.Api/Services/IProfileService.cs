using C101A.Sql.Api.Data;
using C101A.Sql.Api.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C101A.Sql.Api.Services
{
    public interface IProfileService
    {
        Task<Profile> CreateAsync(CreateProfileModel profileModel);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(Guid id);
    }
}