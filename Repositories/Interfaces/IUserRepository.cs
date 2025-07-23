using Skill_Hub.Models;

namespace Skill_Hub.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsers();
        public Task<User?> GetById(int id);
        public Task<User?> GetByName(string name);
        public Task<User?> GetByEmail(string email);
        public Task AddUser(User user);
        public Task<int> UpdateUser(User user, int id);
        public Task<int> DeleteUser(int id);
        public Task<User?> SignIn(string email, string password);
    }
}
