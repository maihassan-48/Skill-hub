using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface IModuleService
    {
        Task<ModuleResponseDto?> GetModuleByIdAsync(int moduleId);
        Task<IEnumerable<ModuleResponseDto>> GetAllModulesByCourseIdAsync(int courseId);
        Task<ModuleResponseDto> AddModuleAsync(CreateModuleDto createModelDto, string token);
        Task UpdateModuleAsync(int id, CreateModuleDto createModuleDto, string token);
        Task DeleteModuleAsync(int moduleId, string token);
    }
}
