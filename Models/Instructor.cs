using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Instructor : User
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        
        public virtual ICollection<Course> CoursesCreated { get; set; } = new List<Course>();
    }
}
