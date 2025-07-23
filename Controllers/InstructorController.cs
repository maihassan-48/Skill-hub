using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skill_Hub.Configurations;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly JwtService _jwtService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";

        public InstructorController(IInstructorService instructorService, JwtService jwtService)
        {
            _instructorService = instructorService;
            _jwtService = jwtService;
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpGet]
        public async Task<IActionResult> GetInstructors()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructor(int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            return Ok(instructor);
        }
    }
}
