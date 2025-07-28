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
            await _context.Enrollments.AddAsync(enrollment);
        }

        public async Task<Enrollment?> GetEnrollmentById(int id)
        {
            return await _context.Enrollments
                .Include(c => c.Course)
                .ThenInclude(x => x.Category)
                .Include(c => c.Course)
                .ThenInclude(i => i.Instructor)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollments(int userId)
        {
            return await _context.Enrollments
                .Include(c => c.Course)
                .ThenInclude(x => x.Category)
                .Include(c => c.Course)
                .ThenInclude(i => i.Instructor)
                .ThenInclude(u => u.User)
                .Where(e => e.Student.StudentId == userId)
                .ToListAsync();
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
