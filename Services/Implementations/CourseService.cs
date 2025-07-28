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
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public CourseService(UnitOfWork unitOfWork, IMapper mapper,JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;

        }

        public async Task<CourseResponseDto?> GetCourseByIdAsync(int courseId)
        {
            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(courseId);
            return course == null ? null : _mapper.Map<CourseResponseDto>(course);
        }

        public async Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllCoursesAsync();
            return _mapper.Map<IEnumerable<CourseResponseDto>>(courses);
        }

        public async Task<IEnumerable<CourseResponseDto>> GetCoursesByCategoryAsync(int categoryId)
        {
            var courses = await _unitOfWork.CourseRepository.GetCoursesByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<CourseResponseDto>>(courses);
        }

        public async Task<IEnumerable<CourseResponseDto>> GetCoursesByInstructorAsync(int instructorId)
        {
            var courses = await _unitOfWork.CourseRepository.GetCoursesByInstructorAsync(instructorId);
            return _mapper.Map<IEnumerable<CourseResponseDto>>(courses);
        }

        public async Task<CourseResponseDto> AddCourseAsync(string token, CreateCourseDto createCourseDto)
        {

            var instructorId = _jwtService.GetUserIdFromToken(token);
            var course =  _mapper.Map<Course>(createCourseDto);
            course.InstructorId = instructorId;
            await _unitOfWork.CourseRepository.AddCourseAsync(course);
            _unitOfWork.Save();
            CourseResponseDto courseResponse = _mapper.Map<CourseResponseDto>(course);
            return courseResponse;
        }

        public async Task UpdateCourseAsync(int id, CreateCourseDto updatedCourseDto, string token)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid course ID.");
            var instructorId = _jwtService.GetUserIdFromToken(token);

            var existingCourse = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);
            if (existingCourse == null)
                throw new InvalidOperationException("Course not found.");

            if (existingCourse.InstructorId != instructorId)
                throw new UnauthorizedAccessException("You are not authorized to update this course.");

            _mapper.Map(updatedCourseDto, existingCourse);
            existingCourse.InstructorId = instructorId;


            await _unitOfWork.CourseRepository.UpdateCourseAsync(existingCourse);
            _unitOfWork.Save();
        }



        public async Task DeleteCourseAsync(int courseId, string token)
        {
            var instructorId = _jwtService.GetUserIdFromToken(token);

            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(courseId);
            if (course == null || course.InstructorId != instructorId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this course.");
            }

            await _unitOfWork.CourseRepository.DeleteCourseAsync(courseId);
            _unitOfWork.Save();
        }

    }

}
