using Microsoft.EntityFrameworkCore;
using Skill_Hub.Data;
using Skill_Hub.Models;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly Context _context;

        public AdminRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAdminAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<Admin?> GetAdminByIdAsync(int id)
        {
            return await _context.Admins
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateAdminAsync(int id, Admin updatedAdmin)
        {
            var admin = await _context.Admins.Where(s => s.Id == id)
                                             .Include(u => u.User)
                                             .FirstOrDefaultAsync();

            if (admin == null) return false;

            admin.User.Name = updatedAdmin.User.Name;
            admin.User.Email = updatedAdmin.User.Email;
            admin.User.Password = updatedAdmin.User.Password;
            admin.Permissions = updatedAdmin.Permissions;

            return true;
        }
    }
}
