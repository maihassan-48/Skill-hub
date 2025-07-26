using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        Task<Instructor?> GetInstructorByIdAsync(int id);
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync();
        Task AddInstructorAsync(Instructor instructor);
        Task UpdateInstructorAsync(Instructor instructor, int id);
    }
}
