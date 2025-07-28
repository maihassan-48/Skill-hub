using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return Ok(course);
        }
        [HttpPost]
        [Authorize(Roles = INSTRUCTOR_ROLE)]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto courseDto)
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            CourseResponseDto newCourse = await _courseService.AddCourseAsync(token, courseDto);
            return Ok(newCourse);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = INSTRUCTOR_ROLE)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCourseDto courseDto)
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            await _courseService.UpdateCourseAsync(id, courseDto, token);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = INSTRUCTOR_ROLE)]
        public async Task<IActionResult> Delete(int id)
        {
            string token = Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            await _courseService.DeleteCourseAsync(id, token);
            return Ok();
        }
    }
}
