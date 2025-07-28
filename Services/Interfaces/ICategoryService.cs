using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto?> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();
        Task<CategoryResponseDto> AddCategoryAsync(CreateCategoryDto category);
        Task UpdateCategoryAsync(int id, CreateCategoryDto category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
