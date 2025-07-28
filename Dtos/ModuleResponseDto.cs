using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Dtos
{
    public class ModuleResponseDto
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        
        public required string Content { get; set; }
        public int Order { get; set; } = 0; 
        public int DurationInMinutes { get; set; } = 0;


        public int CourseId { get; set; }
    }

}
