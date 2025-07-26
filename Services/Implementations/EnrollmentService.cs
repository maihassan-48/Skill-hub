using AutoMapper;
using Azure.Core;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;
        private readonly IMapper _mapper;

        public EnrollmentService(IUnitOfWork unitOfWork, JwtService jwtService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task Enroll(EnrollmentRequestDTO enrollmentDto, string token)
        {
            int userId = _jwtService.GetUserIdFromToken(token);
            Enrollment enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            var student = await _unitOfWork.StudentRepository.GetStudentByIdAsync(userId);
            if (student == null)
            {
                throw new InvalidOperationException("Student not found.");
            }
            enrollment.Student = student;
            enrollment.Course = await _unitOfWork.courseRepository.GetCourseById(enrollmentDto.CourseId);
            await _unitOfWork.enrollmentRepository.Enroll(enrollment);
        }

        public async Task Unenroll(int id)
        {
            await _unitOfWork.enrollmentRepository.Unenroll(id);
        }

        public async Task<IEnumerable<EnrollmentResponseDTO>> GetEnrollments(string token)
        {
            int userId = _jwtService.GetUserIdFromToken(token);
            var enrollments = await _unitOfWork.enrollmentRepository.GetEnrollments(userId);
            return _mapper.Map<IEnumerable<EnrollmentResponseDTO>>(enrollments);
        }

        public async Task<EnrollmentResponseDTO> GetEnrollmentById(int id)
        {
            var enrollment = await _unitOfWork.enrollmentRepository.GetEnrollmentById(id);
            return _mapper.Map<EnrollmentResponseDTO>(enrollment);
        }
    }
}
