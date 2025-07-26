using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public InstructorService(IUnitOfWork unitOfWork, IMapper mapper, JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public Task<SignInResponseDTO> CreateInstructorAsync(InstructorRequestDTO instructorDto)
        {
            var instructor = _mapper.Map<Instructor>(instructorDto);
            _unitOfWork.instructorRepository.AddInstructorAsync(instructor);
            _unitOfWork.Save();

            var token = _jwtService.GenerateToken(instructor.User, instructor.User.Role);
            return Task.FromResult(new SignInResponseDTO
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1),
                UserId = instructor.Id,
                Name = instructor.User.Name,
                Role = instructor.User.Role.ToString()
            });
        }

        public async Task<IEnumerable<InstructorResponseDTO>> GetAllInstructorsAsync()
        {
            var instructors = await _unitOfWork.instructorRepository.GetAllInstructorsAsync();
            return _mapper.Map<IEnumerable<InstructorResponseDTO>>(instructors);
        }

        public async Task<InstructorResponseDTO?> GetInstructorByIdAsync(int id)
        {
            var instructor = await _unitOfWork.instructorRepository.GetInstructorByIdAsync(id);
            return _mapper.Map<InstructorResponseDTO>(instructor);
        }

        public async Task UpdateInstructor(InstructorRequestDTO instructorDto, int id)
        {
            var instructor = _mapper.Map<Instructor>(instructorDto);
            await _unitOfWork.instructorRepository.UpdateInstructorAsync(instructor, id);
            _unitOfWork.Save();

        }
    }
}
