using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course?> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);

        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(int instructorId); 
    }
}
