using EnvironmentVariables.Sql.Api.Data;
using EnvironmentVariables.Sql.Api.Models;
using EnvironmentVariables.Sql.Api.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnvironmentVariables.Sql.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _service;

        public ProfilesController(IProfileService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Profile>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Profile), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var profile = await _service.GetByIdAsync(id);

            if (profile is null)
                return NotFound();

            return Ok(profile);
        }

        [HttpPost(Name = "CreateProfile")]
        [ProducesResponseType(typeof(Profile), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Create(CreateProfileModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return BadRequest("Debe ingresar su nombre.");

            if (string.IsNullOrWhiteSpace(model.Lastname))
                return BadRequest("Debe ingresar su apellido.");

            if (string.IsNullOrWhiteSpace(model.Website) || !Uri.TryCreate(model.Website, UriKind.RelativeOrAbsolute, out _))
                return BadRequest("Debe ingresar un link valido.");

            var profile = await _service.CreateAsync(model);

            return Created(profile.Id.ToString(), profile);
        }

        [HttpDelete("{id}", Name = "DeleteProfile")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var profile = await _service.GetByIdAsync(id);

            if (profile is null)
                return NotFound();

            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
