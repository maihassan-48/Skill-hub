using Microsoft.EntityFrameworkCore;
using Skill_Hub.Models;

namespace Skill_Hub.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
