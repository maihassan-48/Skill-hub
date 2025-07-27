using Skill_Hub.Data;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class UnitOfWork
    {
        private readonly Context _context;
        private ICourseRepository? _courses;
        private ICategoryRepository? _categories;
        private IModuleRepository? _modules;
        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public ICourseRepository Courses => _courses ??= new CourseRepository(_context);
        public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);
        public IModuleRepository Modules => _modules ??= new ModuleRepository(_context);
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
