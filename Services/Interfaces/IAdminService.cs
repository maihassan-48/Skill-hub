using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface IAdminService
    {
        public Task<SignInResponseDTO> CreateAdminAsync(AdminRequestDTO adminDTO);

        public Task<IEnumerable<AdminResponseDTO>> GetAllAdminsAsync();

        public Task<AdminResponseDTO?> GetAdminByIdAsync(int id);

        public Task UpdateAdminAsync(int id, AdminRequestDTO adminDTO);
    }
}
