using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Enums;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillService(IUnitOfWork unitOfWork, IMapper mapper, JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateSkillAsync(SkillRequestDTO skillDTO)
        {
            var skill = _mapper.Map<Skill>(skillDTO);
            await _unitOfWork.SkillRepository.AddSkill(skill);
            _unitOfWork.Save();

            return true;
        }

        public async Task<IEnumerable<SkillResponseDTO>> GetAllSkillsAsync()
        {
            var skills = await _unitOfWork.SkillRepository.GetSkills();
            return _mapper.Map<IEnumerable<SkillResponseDTO>>(skills);
        }

        public async Task<SkillResponseDTO?> GetSkillByIdAsync(int id)
        {
            var skills = await _unitOfWork.SkillRepository.GetSkillById(id);
            return _mapper.Map<SkillResponseDTO>(skills);
        }

        public async Task UpdateSkillAsync(int id, SkillRequestDTO skillDTO)
        {
            if (id != skillDTO.Id)
            {
                throw new Exception("IDs don't match");
            }

            var skill = _mapper.Map<Skill>(skillDTO);

            if (!await _unitOfWork.SkillRepository.UpdateSkill(id, skill))
            {
                throw new Exception("Skill not found");
            }

            _unitOfWork.Save();
        }
        public async Task DeleteSkillAsync(int id)
        {
            if (!await _unitOfWork.SkillRepository.DeleteSkill(id))
            {
                throw new Exception("Skill not found");
            }

            _unitOfWork.Save();
        }
    }
}
