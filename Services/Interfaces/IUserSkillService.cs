using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace UserSkill_Hub.Services.Interfaces
{
    public interface IUserSkillService
    {
        public Task<bool> CreateUserSkillAsync(UserSkillDTO skillDTO);
        public Task<IEnumerable<UserSkillDTO>> GetAllUserSkillsAsync();
        public Task<UserSkillDTO?> GetUserSkillByIdAsync(int id);
        public Task UpdateUserSkillAsync(int id, UserSkillDTO skillDTO);
        public Task DeleteUserSkillAsync(int id);

    }
}
