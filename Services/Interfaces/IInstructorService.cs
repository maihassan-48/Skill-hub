using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public interface IInstructorService
    {
        Task<InstructorResponseDTO?> GetInstructorByIdAsync(int id);
        Task<IEnumerable<InstructorResponseDTO>> GetAllInstructorsAsync();
        Task<SignInResponseDTO> CreateInstructorAsync(InstructorRequestDTO instructor);
    }
}
