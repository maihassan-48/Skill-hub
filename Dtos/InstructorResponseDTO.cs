using Skill_Hub.Enums;

namespace Skill_Hub.Dtos
{
    public class InstructorResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = Role.Instructor;
        public string Department { get; set; }
    }
}
