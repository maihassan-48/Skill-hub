using Skill_Hub.Dtos;

namespace Skill_Hub.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task Enroll(EnrollmentRequestDTO enrollment, string token);
        Task Unenroll(int id);
        Task<IEnumerable<EnrollmentResponseDTO>> GetEnrollments(string token);
        Task<EnrollmentResponseDTO> GetEnrollmentById(int id);
    }
}
