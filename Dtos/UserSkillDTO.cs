using Skill_Hub.Enums;
using Skill_Hub.Models;

namespace Skill_Hub.Dtos
{
    public class UserSkillDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SkillId { get; set; }
        public ProficiencyLevel Level { get; set; } = ProficiencyLevel.Beginner;
    }
}
