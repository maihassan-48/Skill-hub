using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface IUserSkillRepository
    {
        Task<IEnumerable<UserSkill>> GetUserSkills();
        Task<UserSkill?> GetUserSkillById(int id);
        Task AddUserSkill(UserSkill userSkill);
        Task<int> UpdateUserSkill(int id, UserSkill userSkill);
        Task<int> DeleteUserSkill(int id);
    }
}
