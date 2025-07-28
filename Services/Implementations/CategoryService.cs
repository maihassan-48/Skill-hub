using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto?> GetCategoryByIdAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("Invalid category ID.");

            var category = await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(categoryId);
            return category == null ? null : _mapper.Map<CategoryResponseDto>(category);
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
        }

        public async Task<CategoryResponseDto> AddCategoryAsync(CreateCategoryDto categoryDto)
        {
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
                throw new ArgumentException("Category name is required.");

            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.CategoryRepository.AddCategoryAsync(category);
            _unitOfWork.Save();

            return _mapper.Map<CategoryResponseDto>(category);
        }

        public async Task UpdateCategoryAsync(int id, CreateCategoryDto categoryDto)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid category ID.");
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
                throw new ArgumentException("Category name is required.");

            var existing = await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(id);
            if (existing == null)
                throw new InvalidOperationException("Category not found.");

            _mapper.Map(categoryDto, existing); 

            await _unitOfWork.CategoryRepository.UpdateCategoryAsync(existing);
            _unitOfWork.Save();
        }


        public async Task DeleteCategoryAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("Invalid category ID.");

            var existing = await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(categoryId);
            if (existing == null)
                throw new InvalidOperationException("Category not found.");

            await Task.Run(() => _unitOfWork.CategoryRepository.DeleteCategoryAsync(categoryId));
            _unitOfWork.Save();
        }
    }
}
