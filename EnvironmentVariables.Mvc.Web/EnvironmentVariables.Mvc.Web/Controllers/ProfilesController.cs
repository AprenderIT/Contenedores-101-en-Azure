using EnvironmentVariables.Mvc.Web.Models;
using EnvironmentVariables.Mvc.Web.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace EnvironmentVariables.Mvc.Web.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IProfileService _service;

        public ProfilesController(IProfileService service)
        {
            _service = service;
        }



        //// GET: Profiles
        //public async Task<IActionResult> Index()
        //{
        //    var myContext = _context.Profiles.Include(p => p.Website);
        //    return View(await myContext.ToListAsync());
        //}

        // GET: Profiles/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var profile = await _context.Profiles
        //        .Include(p => p.Website)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(profile);
        //}

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Lastname,Website")] CreateProfileModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(model);
            }
            //ViewData["WebsiteId"] = new SelectList(_context.Websites, "Id", "Id", profile.WebsiteId);
            return RedirectToAction("Index", "Home", new { area = "" });

        }

        // GET: Profiles/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var profile = await _context.Profiles.FindAsync(id);
        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["WebsiteId"] = new SelectList(_context.Websites, "Id", "Id", profile.WebsiteId);
        //    return View(profile);
        //}

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Lastname,WebsiteId")] Profile profile)
        //{
        //    if (id != profile.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(profile);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProfileExists(profile.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["WebsiteId"] = new SelectList(_context.Websites, "Id", "Id", profile.WebsiteId);
        //    return View(profile);
        //}

        //GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {


            if (!id.HasValue)
            {
                return NotFound();
            }

            var profile = await _service.GetByIdAsync(id.Value);



            if (profile is null)
            {
                return NotFound();
            }

            return View(profile);
        }

        //POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        //private bool ProfileExists(Guid id)
        //{
        //    return _context.Profiles.Any(e => e.Id == id);
        //}
    }
}
