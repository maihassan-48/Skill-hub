using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public User User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Major { get; set; }
        public virtual List<Enrollment> Enrollments { get; } = [];
        public virtual List<Skill> Skills { get; } = [];

    }
}
