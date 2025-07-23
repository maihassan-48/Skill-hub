using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;
using SkillHub.DTOs;

namespace Skill_Hub.Services.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstructorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstructorResponseDTO>> GetAllInstructorsAsync()
        {
            var instructors =  await _unitOfWork.instructorRepository.GetAllInstructorsAsync();
            return _mapper.Map<IEnumerable<InstructorResponseDTO>>(instructors);
        }

        public async Task<InstructorResponseDTO?> GetInstructorByIdAsync(int id)
        {
            var instructor =  await _unitOfWork.instructorRepository.GetInstructorByIdAsync(id);
            return _mapper.Map<InstructorResponseDTO?>(instructor);
        }
    }
}
