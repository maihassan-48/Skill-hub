using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public User User { get; set; }
        public required string Department { get; set; }
        
    }
}
