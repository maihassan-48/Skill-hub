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
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Create([FromBody] CreateModuleDto moduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newModule = await _moduleService.AddModuleAsync(moduleDto);
            return CreatedAtAction(nameof(GetById), new { id = newModule.Id }, newModule);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Update(int id, [FromBody] Module module)
        {
            await _moduleService.UpdateModuleAsync(module);
            return NoContent();
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Delete(int id)
        {
            await _moduleService.DeleteModuleAsync(id);
            return NoContent();
        }
    }
}
