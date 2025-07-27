using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Enums;
using Skill_Hub.Models;
using System.Security.AccessControl;

namespace Skill_Hub.Services.Interfaces
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<SignInResponseDTO> CreateStudentAsync(StudentRequestDTO studentDTO)
        {
            studentDTO.Role = Role.Student;
            var student = _mapper.Map<Student>(studentDTO);
            await _unitOfWork.StudentRepository.AddStudentAsync(student);
            _unitOfWork.Save();

            var token = _jwtService.GenerateToken(student.User, student.User.Role);
            return await Task.FromResult(new SignInResponseDTO
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1),
                UserId = student.StudentId,
                Name = student.User.Name,
                Role = student.User.Role.ToString()
            });
        }

        public async Task<IEnumerable<StudentResponseDTO>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.StudentRepository.GetAllStudentsAsync();
            return _mapper.Map<IEnumerable<StudentResponseDTO>>(students);
        }

        public async Task<StudentResponseDTO?> GetStudentByIdAsync(int id)
        {
            var students = await _unitOfWork.StudentRepository.GetStudentByIdAsync(id);
            return _mapper.Map<StudentResponseDTO>(students);
        }

        public async Task UpdateStudentAsync(int id, StudentRequestDTO studentDTO)
        {
            if(id != studentDTO.Id)
            {
                throw new Exception("IDs don't match");
            }

            var student = _mapper.Map<Student>(studentDTO);

            if(!await _unitOfWork.StudentRepository.UpdateStudentAsync(id, student))
            {
                throw new Exception("Student not found");
            }

            _unitOfWork.Save();

        }
    }
}
