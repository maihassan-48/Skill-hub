using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Student : User
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
