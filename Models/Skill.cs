using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models;

public class Skill
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public virtual List<Student> Students { get; } = [];
}