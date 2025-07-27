using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin?> GetAdminByIdAsync(int id);
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task AddAdminAsync(Admin admin);
        Task<bool> UpdateAdminAsync(int id, Admin admin);
    }
}
