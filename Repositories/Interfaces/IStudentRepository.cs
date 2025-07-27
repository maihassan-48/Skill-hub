using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int id, Student student);
    }
}
