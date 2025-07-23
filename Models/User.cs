using Skill_Hub.Enums;

namespace Skill_Hub.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; } //plain text for now, add hashing as we go
        public required Role Role { get; set; }

        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public Admin Admin { get; set; }


    }
}
