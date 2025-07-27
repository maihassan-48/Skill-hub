using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.StudentId == id);
        }

        public async Task<int> UpdateStudentAsync(int id, Student updatedStudent)
        {
            return await _context.Students.Where(s => s.StudentId == id).ExecuteUpdateAsync(
                setters => setters
                .SetProperty(s => s.DateOfBirth, updatedStudent.DateOfBirth)
                .SetProperty(s => s.Major, updatedStudent.Major)
                .SetProperty(s => s.User, updatedStudent.User)
                .SetProperty(s => s.Courses, updatedStudent.Courses)
                .SetProperty(s => s.Skills, updatedStudent.Skills)
                );
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            return await _context.Students.Where(s => s.StudentId == id).ExecuteDeleteAsync();
        }
    }
}
