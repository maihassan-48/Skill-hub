using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly Context _context;

        public InstructorRepository(Context context)
        {
            _context = context;
        }

        public async Task AddInstructorAsync(Instructor instructor)
        {
            await _context.Instructors.AddAsync(instructor);
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            return await _context.Instructors
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
        {
            return await _context.Instructors
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateInstructorAsync(Instructor instructor, int id)
        {
            var existingInstructor = await _context.Instructors
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingInstructor != null)
            {
                existingInstructor.Department = instructor.Department;
                existingInstructor.User.Name = instructor.User.Name;
                existingInstructor.User.Email = instructor.User.Email;
                existingInstructor.User.Role = instructor.User.Role;
                existingInstructor.User.Password = instructor.User.Password;
                await _context.SaveChangesAsync();
            }
        }
    }
}
