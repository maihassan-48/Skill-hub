using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Admin : User
    {
        
        [MaxLength(200)]
        public string? Permissions { get; set; }
    }
}
