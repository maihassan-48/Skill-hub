using Skill_Hub.Models;
using Skill_Hub.Repositories.Implementations;

namespace Skill_Hub.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly UnitOfWork _unitOfWork;

        public CourseService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Course?> GetCourseByIdAsync(int courseId)
            => await _unitOfWork.Courses.GetCourseByIdAsync(courseId);

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
            => await _unitOfWork.Courses.GetAllCoursesAsync();

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId)
            => await _unitOfWork.Courses.GetCoursesByCategoryAsync(categoryId);

        public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(int instructorId)
            => await _unitOfWork.Courses.GetCoursesByInstructorAsync(instructorId);

        public async Task AddCourseAsync(Course course)
        {
            await _unitOfWork.Courses.AddCourseAsync(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await Task.Run(() => _unitOfWork.Courses.UpdateCourseAsync(course));
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await Task.Run(() => _unitOfWork.Courses.DeleteCourseAsync(courseId));
            await _unitOfWork.CompleteAsync();
        }
    }

}
