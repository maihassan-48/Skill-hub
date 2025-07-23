using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public User User { get; set; }
        [MaxLength(200)]
        public string? Permissions { get; set; }
    }
}
