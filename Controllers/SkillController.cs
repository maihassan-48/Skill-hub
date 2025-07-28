using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skill_Hub.Configurations;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;
using Skill_Hub.Dtos;

namespace Skill_Hub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly JwtService _jwtService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";

        public SkillController(ISkillService skillService, JwtService jwtService)
        {
            _skillService = skillService;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkill(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            return Ok(skill);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] SkillRequestDTO skill)
        {
            // Assuming you have a method to create an skill in the service
            await _skillService.CreateSkillAsync(skill);
            return Ok();
        }

        [Authorize(Roles = INSTRUCTOR_ADMIN_ROLES)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSkill(int id, SkillRequestDTO skill)
        {
            try
            {
                await _skillService.UpdateSkillAsync(id, skill);
                return Ok("Skill Updated Successfullly");
            }   

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = INSTRUCTOR_ADMIN_ROLES)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            try
            {
                await _skillService.DeleteSkillAsync(id);
                return Ok("Skill Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
