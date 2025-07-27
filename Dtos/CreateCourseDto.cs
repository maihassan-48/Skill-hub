using Skill_Hub.Models;
using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Dtos
{
    public class CreateCourseDto
    {

        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }
        public int InstructorId { get; set; } 

    }
}
