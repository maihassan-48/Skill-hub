using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponseDto?> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync();
        Task<IEnumerable<CourseResponseDto>> GetCoursesByCategoryAsync(int categoryId);
        Task<IEnumerable<CourseResponseDto>> GetCoursesByInstructorAsync(int instructorId);
        Task<CourseResponseDto> AddCourseAsync(string token, CreateCourseDto createCourseDto);
        Task UpdateCourseAsync(int id, CreateCourseDto courseDto, string token);
        Task DeleteCourseAsync(int courseId, string token);
    }
}
