using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task Enroll(Enrollment enrollment);
        Task Unenroll(int id);
        Task<IEnumerable<Enrollment>> GetEnrollments(int userId);
        Task<Enrollment> GetEnrollmentById(int id);
    }
}
