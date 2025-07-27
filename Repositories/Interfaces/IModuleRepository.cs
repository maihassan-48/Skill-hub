using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        Task<Module?> GetModuleByIdAsync(int moduleId);
        Task<IEnumerable<Module>> GetAllModulesByCourseIdAsync(int courseId);
        Task<Module> AddModuleAsync(Module module);
        Task UpdateModuleAsync(Module module);
        Task DeleteModuleAsync(int moduleId);

    }
}
