using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skill_Hub.Dtos;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDTO signInRequest)
        {
            var result = await _userService.SignIn(signInRequest);
            
            return Ok(result);
        }

        [Authorize(Roles = INSTRUCTOR_ADMIN_ROLES)]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [Authorize(Roles = INSTRUCTOR_ADMIN_ROLES)]
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [Authorize(Roles = INSTRUCTOR_ADMIN_ROLES)]
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var user = await _userService.GetByName(name);
            return Ok(user);
        }

        [Authorize(Roles = INSTRUCTOR_ADMIN_ROLES)]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetByEmail(email);
            return Ok(user);
        }

        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UserRequestDTO userRequest, int id)
        {
            await _userService.Update(userRequest, id);
            return Ok();
        }

        [Authorize(Roles = INSTRUCTOR_ADMIN_ROLES)]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
