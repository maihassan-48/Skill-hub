using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface ISkillService
    {
        public Task<bool> CreateSkillAsync(SkillRequestDTO skillDTO);

        public Task<IEnumerable<SkillResponseDTO>> GetAllSkillsAsync();

        public Task<SkillResponseDTO?> GetSkillByIdAsync(int id);

        public Task UpdateSkillAsync(int id, SkillRequestDTO skillDTO);
        public Task DeleteSkillAsync(int id);

    }
}
