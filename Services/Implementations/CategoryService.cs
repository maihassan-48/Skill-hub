using AutoMapper;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Implementations;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
            => await _unitOfWork.Categories.GetCategoryByIdAsync(categoryId);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            => await _unitOfWork.Categories.GetAllCategoriesAsync();

        public async Task<Category> AddCategoryAsync(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Categories.AddCategoryAsync(category);
            await _unitOfWork.CompleteAsync();

            return category;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await Task.Run(() => _unitOfWork.Categories.UpdateCategoryAsync(category));
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await Task.Run(() => _unitOfWork.Categories.DeleteCategoryAsync(categoryId));
            await _unitOfWork.CompleteAsync();
        }
    }

}
