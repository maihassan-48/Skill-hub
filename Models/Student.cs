using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public User User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Major { get; set; }
        public virtual List<Course> Courses { get; } = [];
        public virtual List<Skill> Skills { get; } = [];

    }
}
