using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface IInstructorService
    {
        Task<Instructor?> GetInstructorByIdAsync(int id);
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync();
    }
}
