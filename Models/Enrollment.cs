using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompletionDate { get; set; }
        [Range(0, 100)]
        public int ProgressPercentage { get; set; } = 0;


        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;

        public bool IsCompleted => CompletionDate.HasValue && CompletionDate.Value <= DateTime.UtcNow;

    }
}
