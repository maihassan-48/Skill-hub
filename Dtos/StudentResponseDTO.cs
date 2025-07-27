using Skill_Hub.Enums;

namespace Skill_Hub.Dtos
{
    public class StudentResponseDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = Role.Student;
        public DateTime DateOfBirth { get; set; }
        public string Major { get; set; }
    }
}
