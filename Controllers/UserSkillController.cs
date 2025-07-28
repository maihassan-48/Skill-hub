using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skill_Hub.Dtos;
using Skill_Hub.Services.Interfaces;
using UserSkill_Hub.Services.Interfaces;

namespace Skill_Hub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillService _userSkillService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";

        public UserSkillController(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserSkillDTO userSkill)
        {
            try
            {
                await _userSkillService.CreateUserSkillAsync(userSkill);
                return Ok(userSkill);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Unregister(int id)
        {
            try {
                await _userSkillService.DeleteUserSkillAsync(id); 
                return Ok("Unregistered successful");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserSkills()
        {
            var userSkills = await _userSkillService.GetAllUserSkillsAsync();
            return Ok(userSkills);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserSkillById(int id)
        {
            var userSkill = await _userSkillService.GetUserSkillByIdAsync(id);
            return Ok(userSkill);
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserSkill(int id, UserSkillDTO userSkillDTO)
        {
            try
            {
                await _userSkillService.UpdateUserSkillAsync(id, userSkillDTO);
                return Ok("User skill updated successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
