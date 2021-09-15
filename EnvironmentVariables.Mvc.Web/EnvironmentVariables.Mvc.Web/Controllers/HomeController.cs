using EnvironmentVariables.Mvc.Web.Data;
using EnvironmentVariables.Mvc.Web.Helpers;
using EnvironmentVariables.Mvc.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentVariables.Mvc.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var profile = await _context.Profiles.AsNoTracking().Include(x => x.Website).ToListAsync();

            return View(new IndexModel(profile));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult EnvironmentVariables(string search)
        {
            var variables = ((Hashtable)Environment.GetEnvironmentVariables())
                .HashtableToDictionary<string, string>()
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (!string.IsNullOrWhiteSpace(search))
            {
                variables = variables.Where(x => x.Key.ToLower().Contains(search.ToLower()) || x.Value.ToLower().Contains(search.ToLower()))
                .ToDictionary(x => x.Key, x => x.Value);
            }

            return View(new EnvironmentVariableModel(variables, search));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
