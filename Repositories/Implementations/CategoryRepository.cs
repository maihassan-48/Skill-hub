using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly Context _context;
        public CategoryRepository(Context context)
        {
            this._context = context;
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categorys.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categorys.ToListAsync();
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categorys.AddAsync(category);
        }

        public Task UpdateCategoryAsync(Category category)
        {
            _context.Categorys.Update(category);
            return Task.CompletedTask;
        }

        public Task DeleteCategoryAsync(int categoryId)
        {
            Category category = new() { Id = categoryId, Name = string.Empty };
            _context.Categorys.Attach(category);
            _context.Categorys.Remove(category);
            return Task.CompletedTask;
        }

    }
}
