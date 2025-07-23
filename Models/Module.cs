using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }
        public int Order { get; set; } = 0; // reresents the index of the module in the course
        public int DurationInMinutes { get; set; } = 0;
        public required virtual Course Course { get; set; }
    }
}
