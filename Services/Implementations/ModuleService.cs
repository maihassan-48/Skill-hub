using AutoMapper;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModuleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Module?> GetModuleByIdAsync(int moduleId)
        {
            return await _unitOfWork.Modules.GetModuleByIdAsync(moduleId);
        }

        public async Task<IEnumerable<Module>> GetAllModulesByCourseIdAsync(int courseId)
        {
            return await _unitOfWork.Modules.GetAllModulesByCourseIdAsync(courseId);
        }

        public async Task<Module> AddModuleAsync(CreateModuleDto createModuleDto)
        {
            var module = _mapper.Map<Module>(createModuleDto);
            var addedModule = await _unitOfWork.Modules.AddModuleAsync(module);
            await _unitOfWork.CompleteAsync();
            return addedModule;
        }

        public async Task UpdateModuleAsync(Module module)
        {
            await _unitOfWork.Modules.UpdateModuleAsync(module);
            await _unitOfWork.CompleteAsync();
        }
        public async Task DeleteModuleAsync(int moduleId)
        {
            await _unitOfWork.Modules.DeleteModuleAsync(moduleId);
            await _unitOfWork.CompleteAsync();


        }
    }
}
