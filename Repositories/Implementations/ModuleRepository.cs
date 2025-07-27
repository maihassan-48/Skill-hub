using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class ModuleRepository : IModuleRepository
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
            return await _context.Courses.Where(c => c.Id == courseId)
                .SelectMany(c => c.Modules)
                .ToListAsync();
        }
        public Task AddModuleAsync(Module module)
        {
            _context.Modules.Add(module);
            return Task.CompletedTask;

        }
        public Task UpdateModuleAsync(Module module)
        {
            _context.Modules.Update(module);
            return Task.CompletedTask;
        }
        public  Task DeleteModuleAsync(int moduleId)
        {
            //var module = new Module { Id = moduleId };
            //_context.Modules.Remove(module);
            //return Task.CompletedTask;
            return Task.CompletedTask;

        }
    }
}
