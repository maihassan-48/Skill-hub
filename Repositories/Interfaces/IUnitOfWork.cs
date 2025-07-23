namespace Skill_Hub.Repositories.Interfaces
{
    // IUnitOfWork.cs
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        ICategoryRepository Categories { get; }
        Task<int> CompleteAsync();
    }

}
