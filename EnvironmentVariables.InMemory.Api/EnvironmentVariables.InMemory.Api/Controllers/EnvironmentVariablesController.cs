using EnvironmentVariables.InMemory.Api.Helpers;
using EnvironmentVariables.InMemory.Api.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections;
using System.Linq;

namespace EnvironmentVariables.InMemory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentVariablesController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(EnvironmentVariableModel), 200)]
        public IActionResult GetAll([FromQuery] string search)
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

            return Ok(new EnvironmentVariableModel(variables, search));
        }

    }
}
