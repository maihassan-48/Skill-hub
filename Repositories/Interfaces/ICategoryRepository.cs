using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);


    }
}
