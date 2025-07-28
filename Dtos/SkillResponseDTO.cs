using Skill_Hub.Enums;

namespace Skill_Hub.Dtos
{
    public class SkillResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
