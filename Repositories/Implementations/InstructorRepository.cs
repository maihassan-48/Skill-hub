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
    }
}
