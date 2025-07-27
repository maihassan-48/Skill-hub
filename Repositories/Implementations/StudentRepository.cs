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

        public async Task<bool> UpdateStudentAsync(int id, Student updatedStudent)
        {
            var student = await _context.Students.Where(s => s.StudentId == id)
                                 .Include(u => u.User)
                                 .FirstOrDefaultAsync();

            if (student == null) return false;

            student.User.Name = updatedStudent.User.Name;
            student.User.Email = updatedStudent.User.Email;
            student.User.Password = updatedStudent.User.Password;
            student.Major = updatedStudent.Major;
            student.DateOfBirth = updatedStudent.DateOfBirth;

            return true;
        }
    }
}
