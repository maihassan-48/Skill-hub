using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetSkills();
        Task<Skill?> GetSkillById(int id);
        Task AddSkill(Skill skill);
        Task<bool> UpdateSkill(int id, Skill skill);
        Task<bool> DeleteSkill(int id);
    }
}
