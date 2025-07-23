using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserResponseDTO>> GetAll();
        public Task<UserResponseDTO?> GetById(int id);
        public Task<UserResponseDTO?> GetByName(string name);
        public Task<UserResponseDTO?>  GetByEmail(string email);
        public Task<SignInResponseDTO> Create(UserRequestDTO user);
        public Task Update(UserRequestDTO user, int id);
        public Task Delete(int id);
        public Task<SignInResponseDTO> SignIn(SignInRequestDTO signInRequestDTO);
    }
}
