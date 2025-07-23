using Skill_Hub.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillHub.DTOs
{
    public class AdminRequestDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; } = Role.Admin;

        [MaxLength(200)]
        public string? Permissions { get; set; }


    }
}
