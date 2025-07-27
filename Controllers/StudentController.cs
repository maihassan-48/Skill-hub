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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly JwtService _jwtService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";

        public StudentController(IStudentService studentService, JwtService jwtService)
        {
            _studentService = studentService;
            _jwtService = jwtService;
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            return Ok(student);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDTO student)
        {
            // Assuming you have a method to create an student in the service
            var signInResponse = await _studentService.CreateStudentAsync(student);
            return Ok(signInResponse);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(int id, StudentRequestDTO student)
        {
            try
            {
                await _studentService.UpdateStudentAsync(id, student);
                return Ok("Student Updated Successfullly");
            }   

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
                return Ok("Student Deleted Successfully");
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
