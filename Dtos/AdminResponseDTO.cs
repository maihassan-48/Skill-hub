using Skill_Hub.Enums;

namespace SkillHub.DTOs
{
    public class AdminResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = Role.Admin;
        public string? Permissions { get; set; }

    }
}
