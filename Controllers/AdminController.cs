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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly JwtService _jwtService;
        private const string STUDENT_ROLE = "1";
        private const string INSTRUCTOR_ROLE = "2";
        private const string ADMIN_ROLE = "3";
        private const string INSTRUCTOR_ADMIN_ROLES = "2,3";

        public AdminController(IAdminService adminService, JwtService jwtService)
        {
            _adminService = adminService;
            _jwtService = jwtService;
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            return Ok(admin);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminRequestDTO admin)
        {
            // Assuming you have a method to create an admin in the service
            var signInResponse = await _adminService.CreateAdminAsync(admin);
            return Ok(signInResponse);
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(int id, AdminRequestDTO admin)
        {
            try
            {
                await _adminService.UpdateAdminAsync(id, admin);
                return Ok("Admin Updated Successfullly");
            }   

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = ADMIN_ROLE)]
        [HttpDelete]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            try
            {
                await _adminService.DeleteAdminAsync(id);
                return Ok("Admin Deleted Successfully");
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
