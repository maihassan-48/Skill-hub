using Skill_Hub.Enums;

namespace Skill_Hub.Models
{
    public class UserSkill
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!; 
        public int SkillId { get; set; }
        public Skill Skill { get; set; } = null!;
        public ProficiencyLevel Level { get; set; } = ProficiencyLevel.Beginner;

    }
}