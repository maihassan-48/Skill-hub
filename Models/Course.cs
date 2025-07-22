using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Skill_Hub.Models
{
    public class Course
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int InstructorId { get; set; }
        public User Instructor { get; set; } = null!;

        public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }

}
