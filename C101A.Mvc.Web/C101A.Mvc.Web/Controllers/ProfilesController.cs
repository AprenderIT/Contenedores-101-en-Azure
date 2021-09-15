using C101A.Mvc.Web.Models;
using C101A.Mvc.Web.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace C101A.Mvc.Web.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IProfileService _service;

        public ProfilesController(IProfileService service)
        {
            _service = service;
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
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
    }
}
