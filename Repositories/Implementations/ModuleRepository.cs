using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class ModuleRepository: IModuleRepository
    {
        private readonly Context _context;
        public ModuleRepository(Context context)
        {
            _context = context;
        }
        public async Task<Module?> GetModuleByIdAsync(int moduleId)
        {
            return await _context.Modules.FindAsync(moduleId);
        }
        public async Task<IEnumerable<Module>> GetAllModulesByCourseIdAsync(int courseId)
        {
            return await _context.Modules
                .Include(m => m.Course)
                .Where(m => m.Course.Id == courseId)
                .ToListAsync();
        }
        public async Task<Module> AddModuleAsync(Module module)
        {
            await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
            return module;
        }
        public async Task UpdateModuleAsync(Module module)
        {
            _context.Modules.Update(module);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteModuleAsync(int moduleId)
        {
            Module module = new() { Id = moduleId, Title = string.Empty, Content = null!, Course = null! };
            _context.Modules.Attach(module);
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
        }
}
