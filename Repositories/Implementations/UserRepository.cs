using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<int> UpdateUser(User user, int id)
        {
            return await _context.Users.Where(u => u.Id == id).ExecuteUpdateAsync(u => u
                .SetProperty(u => u.Name, user.Name)
                .SetProperty(u => u.Email, user.Email)
                .SetProperty(u => u.Password, user.Password)
                .SetProperty(u => u.Role, user.Role));
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        public async Task<User?> SignIn(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
