using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface IModuleService
    {
        Task<Module?> GetModuleByIdAsync(int moduleId);
        Task<IEnumerable<Module>> GetAllModulesByCourseIdAsync(int courseId);
        Task<Module> AddModuleAsync(CreateModuleDto createModelDto, string token);
        Task UpdateModuleAsync(Module module, string token);
        Task DeleteModuleAsync(int moduleId, string token);
    }
}
