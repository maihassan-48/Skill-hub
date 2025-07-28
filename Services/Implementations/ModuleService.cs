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
        private readonly JwtService _jwtService;

        public ModuleService(IUnitOfWork unitOfWork, IMapper mapper, JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<ModuleResponseDto?> GetModuleByIdAsync(int moduleId)
        {
            var module = await _unitOfWork.ModuleRepository.GetModuleByIdAsync(moduleId);
            return module == null ? null : _mapper.Map<ModuleResponseDto>(module);
        }

        public async Task<IEnumerable<ModuleResponseDto>> GetAllModulesByCourseIdAsync(int courseId)
        {
            var modules = await _unitOfWork.ModuleRepository.GetAllModulesByCourseIdAsync(courseId);
            return _mapper.Map<IEnumerable<ModuleResponseDto>>(modules);
        }

        public async Task<ModuleResponseDto> AddModuleAsync(CreateModuleDto createModuleDto, string token)
        {
            var instructorId = _jwtService.GetUserIdFromToken(token);

            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(createModuleDto.CourseId);
            if (course == null || course.InstructorId != instructorId)
                throw new UnauthorizedAccessException("You are not authorized to add a module to this course.");

            var module = _mapper.Map<Module>(createModuleDto);
            await _unitOfWork.ModuleRepository.AddModuleAsync(module);
            _unitOfWork.Save();
            return _mapper.Map<ModuleResponseDto>(module);
        }

        public async Task UpdateModuleAsync(int id, CreateModuleDto moduleDto, string token)
        {
            var instructorId = _jwtService.GetUserIdFromToken(token);

            var existingModule = await _unitOfWork.ModuleRepository.GetModuleByIdAsync(id);
            if (existingModule == null)
                throw new InvalidOperationException("Module not found.");

            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(existingModule.CourseId);
            if (course == null || course.InstructorId != instructorId)
                throw new UnauthorizedAccessException("You are not authorized to update this module.");

            _mapper.Map(moduleDto, existingModule);
            await _unitOfWork.ModuleRepository.UpdateModuleAsync(existingModule);
            _unitOfWork.Save();
        }

        public async Task DeleteModuleAsync(int moduleId, string token)
        {
            var instructorId = _jwtService.GetUserIdFromToken(token);

            var module = await _unitOfWork.ModuleRepository.GetModuleByIdAsync(moduleId);
            if (module == null)
                throw new InvalidOperationException("Module not found.");

            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(module.CourseId);
            if (course == null || course.InstructorId != instructorId)
                throw new UnauthorizedAccessException("You are not authorized to delete this module.");

            await _unitOfWork.ModuleRepository.DeleteModuleAsync(moduleId);
            _unitOfWork.Save();
        }
    }
}
