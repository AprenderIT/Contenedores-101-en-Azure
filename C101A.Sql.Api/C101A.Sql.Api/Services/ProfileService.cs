using C101A.Sql.Api.Data;
using C101A.Sql.Api.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C101A.Sql.Api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly MyContext _context;
        private readonly IWebsiteService _websiteService;

        public ProfileService(MyContext context, IWebsiteService websiteService)
        {
            _context = context;
            _websiteService = websiteService;
        }

        public async Task<IEnumerable<Profile>> GetAllAsync()
            => await _context.Profiles.AsNoTracking().Include(x => x.Website).ToListAsync();

        public Task<Profile> GetByIdAsync(Guid id)
            => _context.Profiles.AsNoTracking().Include(x => x.Website).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Profile> CreateAsync(CreateProfileModel profileModel)
        {
            var website = await _websiteService.CreateAsync(new Uri(profileModel.Website));

            Profile profile = new()
            {
                Name = profileModel.Name,
                Lastname = profileModel.Lastname,
                WebsiteId = website.Id,
                CreationTime = DateTime.UtcNow
            };

            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task DeleteAsync(Guid id)
        {
            var profile = await _context.Profiles.Include(x => x.Website).SingleAsync(x => x.Id == id);

            _context.Remove(profile);

            await _context.SaveChangesAsync();
        }
    }
}
