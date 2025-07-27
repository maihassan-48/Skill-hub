using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
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
            return await _unitOfWork.ModuleRepository.GetModuleByIdAsync(moduleId);
        }

        public async Task<IEnumerable<Module>> GetAllModulesByCourseIdAsync(int courseId)
        {
            return await _unitOfWork.ModuleRepository.GetAllModulesByCourseIdAsync(courseId);
        }

        public async Task<Module> AddModuleAsync(CreateModuleDto createModuleDto)
        {
            var module = _mapper.Map<Module>(createModuleDto);
            await _unitOfWork.ModuleRepository.AddModuleAsync(module);
            _unitOfWork.Save();
            return module;
        }

        public async Task UpdateModuleAsync(Module module)
        {
            await _unitOfWork.ModuleRepository.UpdateModuleAsync(module);
            _unitOfWork.Save();
        }
        public async Task DeleteModuleAsync(int moduleId)
        {
            await _unitOfWork.ModuleRepository.DeleteModuleAsync(moduleId);
            _unitOfWork.Save();
        }

        public Task<Module> AddModuleAsync(CreateModuleDto createModelDto, string token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateModuleAsync(Module module, string token)
        {
            throw new NotImplementedException();
        }

        public Task DeleteModuleAsync(int moduleId, string token)
        {
            throw new NotImplementedException();
        }
    }
}
