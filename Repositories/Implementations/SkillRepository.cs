using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class SkillRepository : ISkillRepository
    {
        private readonly Context _context;
        public SkillRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Skill>> GetSkills()
        {
            var skills = await _context.Skills.AsNoTracking().ToListAsync();

            return skills;
        }

        public async Task<Skill?> GetSkillById(int id)
        {
            var skill = await _context.Skills.AsNoTracking().Where(sk => sk.Id == id).FirstOrDefaultAsync();

            return skill;
        }


        public async Task AddSkill(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public async Task<bool> DeleteSkill(int id)
        {
            int affectedRows = await _context.Skills.Where(sk => sk.Id == id)
                                                    .ExecuteDeleteAsync();

            if (affectedRows == 0) return false;

            return true;
        }

        public async Task<bool> UpdateSkill(int id, Skill UpdatedSkill)
        {
            var skill = await _context.Skills.Where(sk => sk.Id == id)
                                        .FirstOrDefaultAsync();

            if (skill == null) return false;

            skill.Description = UpdatedSkill.Description;
            skill.Name = UpdatedSkill.Name;

            return true;
        }
    }
}
