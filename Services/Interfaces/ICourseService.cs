using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Course?> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId);
        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(int instructorId);
        Task<Course> AddCourseAsync(CreateCourseDto createCourseDto, string token);
        Task UpdateCourseAsync(Course course, string token);
        Task DeleteCourseAsync(int courseId, string token);
    }
}
