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

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
            => await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(categoryId);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            => await _unitOfWork.CategoryRepository.GetAllCategoriesAsync();

        public async Task<Category> AddCategoryAsync(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.CategoryRepository.AddCategoryAsync(category);
            _unitOfWork.Save();

            return category;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await Task.Run(() => _unitOfWork.CategoryRepository.UpdateCategoryAsync(category));
            _unitOfWork.Save();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await Task.Run(() => _unitOfWork.CategoryRepository.DeleteCategoryAsync(categoryId));
            _unitOfWork.Save();
        }
    }

}
