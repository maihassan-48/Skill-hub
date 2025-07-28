using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly Context _context;

        public UserSkillRepository(Context context)
        {
            _context = context;
        }
        public async Task AddUserSkill(UserSkill userSkill)
        {
            await _context.UserSkills.AddAsync(userSkill);
        }

        public async Task<int> DeleteUserSkill(int id)
        {
            int affectedRows = await _context.UserSkills.Where(sk => sk.Id == id).ExecuteDeleteAsync();
            return affectedRows;
        }

        public async Task<UserSkill?> GetUserSkillById(int id)
        {
            return await _context.UserSkills.FindAsync(id);
        }

        public async Task<IEnumerable<UserSkill>> GetUserSkills()
        {
            return await _context.UserSkills.ToListAsync();
        }

        public async Task<int> UpdateUserSkill(int id, UserSkill userSkill)
        {
            int affectedRows = await _context.UserSkills.Where(sk => sk.Id == id).ExecuteUpdateAsync(
                setters => setters
                .SetProperty(s => s.StudentId, userSkill.StudentId)
                .SetProperty(s => s.SkillId, userSkill.SkillId)
                .SetProperty(s => s.Level, userSkill.Level)
                );

            return affectedRows;
        }
    }
}
