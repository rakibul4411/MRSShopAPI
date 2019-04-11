using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FwCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FwApi.AppIdentity
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        // GET: api/Role
        [HttpGet]
        [Route("roles")]
        public IActionResult Get()
        {
            var role = _roleManager.Roles.ToList();
            return Ok(role);
        }

        // GET: api/Role/details/5
        [HttpGet("{id}")]
        [Route("details")]
        public async Task<IActionResult> Get(string id)
        {
            var model = await _roleManager.FindByIdAsync(id);
            return Ok(model);
        }

        // POST: api/Role
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post([FromBody] IdentityRole model)
        {
            var role = await _roleManager.CreateAsync(model);

            return Ok(role);
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        [Route("update")]
        public async Task<IActionResult> Put(string id, [FromBody] IdentityRole model)
        {
            var oldRole = await _roleManager.FindByIdAsync(model.Id);
            oldRole.Name = model.Name;

            if (oldRole != null)
            {
                var Update = await _roleManager.UpdateAsync(model);
                return Ok(model);
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                var role = await _roleManager.FindByIdAsync(id);
                var delete = await _roleManager.DeleteAsync(role);
                return Ok();
            }
            return NoContent();
        }

    }//c
}//ns