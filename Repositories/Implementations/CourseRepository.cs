using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Context _context;

        public CourseRepository(Context context)
        {
            _context = context;
        }

        public async Task<Course?> GetCourseByIdAsync(int courseId)
        {
            return await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId)
        {
            return await _context.Courses
                .Where(c => c.Category.Id == categoryId)
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            return Task.CompletedTask;
        }

        public Task DeleteCourseAsync(int courseId)
        {
            var course = new Course { Id = courseId };
            _context.Courses.Attach(course);
            _context.Courses.Remove(course);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(int instructorId)
        {
            return await _context.Courses
                .Where(c => c.Instructor.Id == instructorId)
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .ToListAsync();
        }
    }
}
