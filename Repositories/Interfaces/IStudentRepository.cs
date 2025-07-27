using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task<int> UpdateStudentAsync(int id, Student student);
        Task<int> DeleteStudentAsync(int id);
    }
}
