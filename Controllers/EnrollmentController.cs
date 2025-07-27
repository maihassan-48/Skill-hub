using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skill_Hub.Dtos;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [Authorize(Roles = STUDENT_ROLE)]
        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] EnrollmentRequestDTO enrollment)
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            await _enrollmentService.Enroll(enrollment, token);
            return Ok(enrollment);
        }

        [Authorize(Roles = STUDENT_ROLE)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Unenroll(int id)
        {
            await _enrollmentService.Unenroll(id);
            return Ok(new { message = "Unenrollment successful" });
        }

        [Authorize(Roles = STUDENT_ROLE)]
        [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            var enrollments = await _enrollmentService.GetEnrollments(token);
            return Ok(enrollments);
        }

        [Authorize(Roles = STUDENT_ROLE)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentById(id);
            return Ok(enrollment);
        }
    }
}
