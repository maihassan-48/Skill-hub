using Skill_Hub.Enums;

namespace Skill_Hub.Dtos
{
    public class StudentRequestDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; } = Role.Student;
        public DateTime DateOfBirth { get; set; }
        public required string Major { get; set; }
    }
}
