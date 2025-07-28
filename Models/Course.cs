using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Skill_Hub.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;

        public virtual List<Enrollment> Enrollments { get; } = [];
        public virtual List<Module> Modules { get; } = [];
    }

}
