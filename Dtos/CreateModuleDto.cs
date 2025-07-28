namespace Skill_Hub.Dtos
{
    public class CreateModuleDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; } = 0;
        public int CourseId { get; set; }
        public int Order { get; set; }
    }
}
