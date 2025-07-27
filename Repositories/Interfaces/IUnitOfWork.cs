namespace Skill_Hub.Repositories.Interfaces
{
    // IUnitOfWork.cs
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        ICategoryRepository Categories { get; }
        IModuleRepository Modules { get; }
        Task<int> CompleteAsync();
    }

}
