using Skill_Hub.Enums;

namespace Skill_Hub.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Role Role { get; set; }

    }
}
