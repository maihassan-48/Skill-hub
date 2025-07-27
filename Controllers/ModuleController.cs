using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Controllers
{
    public class ModuleController: ControllerBase
    {
        private readonly IModuleService _moduleService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }
       
        [HttpGet("course/{id}")]
        public async Task<IActionResult> GetAllByCourseId(int id)
        {
            var modules = await _moduleService.GetAllModulesByCourseIdAsync(id);
            return Ok(modules);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var module = await _moduleService.GetModuleByIdAsync(id);
            if (module == null)
                return NotFound();
            return Ok(module);
        }
        [HttpPost]
        [Authorize(Roles = INSTRUCTOR_ROLE)]
        public async Task<IActionResult> Create([FromBody] CreateModuleDto moduleDto)
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newModule = await _moduleService.AddModuleAsync(moduleDto, token);
            return CreatedAtAction(nameof(GetById), new { id = newModule.Id }, newModule);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = INSTRUCTOR_ROLE)]
        public async Task<IActionResult> Update(int id, [FromBody] Module module)
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            await _moduleService.UpdateModuleAsync(module, token);
            return NoContent();
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = INSTRUCTOR_ROLE)]
        public async Task<IActionResult> Delete(int id)
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            await _moduleService.DeleteModuleAsync(id, token);
            return NoContent();
        }
    }
}
