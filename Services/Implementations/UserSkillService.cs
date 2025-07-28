using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;
using UserSkill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class UserSkillService : IUserSkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public UserSkillService(IUnitOfWork unitOfWork, IMapper mapper, JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<bool> CreateUserSkillAsync(UserSkillDTO userSkillDTO)
        {
            var userSkill = _mapper.Map<UserSkill>(userSkillDTO);
            await _unitOfWork.UserSkillRepository.AddUserSkill(userSkill);
            _unitOfWork.Save();

            return true;
        }

        public async Task<IEnumerable<UserSkillDTO>> GetAllUserSkillsAsync()
        {
            var userSkills = await _unitOfWork.UserSkillRepository.GetUserSkills();
            return _mapper.Map<IEnumerable<UserSkillDTO>>(userSkills);
        }

        public async Task<UserSkillDTO?> GetUserSkillByIdAsync(int id)
        {
            var userSkill = await _unitOfWork.UserSkillRepository.GetUserSkillById(id);
            return _mapper.Map<UserSkillDTO>(userSkill);
        }

        public async Task UpdateUserSkillAsync(int id, UserSkillDTO userSkillDTO)
        {
            if (id != userSkillDTO.Id)
            {
                throw new Exception("IDs don't match");
            }

            var userSkill = _mapper.Map<UserSkill>(userSkillDTO);

            if (await _unitOfWork.UserSkillRepository.UpdateUserSkill(id, userSkill) == 0)
            {
                throw new Exception("UserSkill not found");
            }

            _unitOfWork.Save();
        }
        public async Task DeleteUserSkillAsync(int id)
        {
            if (await _unitOfWork.UserSkillRepository.DeleteUserSkill(id) == 0)
            {
                throw new Exception("UserSkill not found");
            }

            _unitOfWork.Save();
        }
    }
}