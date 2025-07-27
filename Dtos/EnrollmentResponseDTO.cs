namespace Skill_Hub.Dtos
{
    public class EnrollmentResponseDTO
    {
        public int Id { get; set; }
        public DateTime CompletionDate { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CategoryName { get; set; }    
        public string InstructorName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int ProgressPercentage { get; set; }
    }
}
