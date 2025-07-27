using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly Context _context;
        public EnrollmentRepository(Context context)
        {
            _context = context;
        }
        public async Task Enroll(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task<Enrollment> GetEnrollmentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollments(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task Unenroll(int id)
        {
            if (await _context.Enrollments.Where(e => e.Id == id).ExecuteDeleteAsync() <= 0)
            {
                throw new Exception("Unenrollment failed. Enrollment not found");
            }
        }
    }
}
