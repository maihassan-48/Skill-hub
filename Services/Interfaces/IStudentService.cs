using Microsoft.AspNetCore.Mvc;
using Skill_Hub.Dtos;

namespace Skill_Hub.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponseDTO?> GetStudentByIdAsync(int id);
        Task<IEnumerable<StudentResponseDTO>> GetAllStudentsAsync();
        Task<SignInResponseDTO> CreateStudentAsync(StudentRequestDTO student);
        Task<int> UpdateStudentAsync(int id, StudentRequestDTO student);
        Task<int> DeleteStudentAsync(int id);
    }
}
