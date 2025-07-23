using System.ComponentModel.DataAnnotations;

namespace Skill_Hub.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompletionDate { get; set; }
        [Range(0, 100)]
        public int ProgressPercentage { get; set; } = 0;

        public bool IsCompleted => CompletionDate.HasValue && CompletionDate.Value <= DateTime.UtcNow;

    }
}
