using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Implementations;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _map;
        private readonly JwtService _jwtService;

        public CourseService(UnitOfWork unitOfWork, IMapper map,JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _map = map;
            _jwtService = jwtService;

        }

        public async Task<Course?> GetCourseByIdAsync(int courseId)
            => await _unitOfWork.Courses.GetCourseByIdAsync(courseId);

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
            => await _unitOfWork.Courses.GetAllCoursesAsync();

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId)
            => await _unitOfWork.Courses.GetCoursesByCategoryAsync(categoryId);

        public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(int instructorId)
            => await _unitOfWork.Courses.GetCoursesByInstructorAsync(instructorId);

        public async Task<Course> AddCourseAsync(CreateCourseDto createCourseDto, string token)
        {
            var id = _jwtService.GetUserIdFromToken(token);
            var course =  _map.Map<Course>(createCourseDto);
            course.Instructor.Id = id;
            await _unitOfWork.Courses.AddCourseAsync(course);
            await _unitOfWork.CompleteAsync();
            return course;
        }

        public async Task UpdateCourseAsync(Course updatedCourse, string token)
        {
            var instructorId = _jwtService.GetUserIdFromToken(token);

            var existingCourse = await _unitOfWork.Courses.GetCourseByIdAsync(updatedCourse.Id);
            if (existingCourse == null || existingCourse.InstructorId != instructorId)
            {
                throw new UnauthorizedAccessException("You are not authorized to update this course.");
            }

            updatedCourse.InstructorId = instructorId;

            await _unitOfWork.Courses.UpdateCourseAsync(updatedCourse);
            await _unitOfWork.CompleteAsync();
        }


        public async Task DeleteCourseAsync(int courseId, string token)
        {
            var instructorId = _jwtService.GetUserIdFromToken(token);

            var course = await _unitOfWork.Courses.GetCourseByIdAsync(courseId);
            if (course == null || course.InstructorId != instructorId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this course.");
            }

            await _unitOfWork.Courses.DeleteCourseAsync(courseId);
            await _unitOfWork.CompleteAsync();
        }

    }

}
