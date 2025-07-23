using Microsoft.EntityFrameworkCore;
using Skill_Hub.Models;

namespace Skill_Hub.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Enrollment> Enrollments { get; set;}
        public DbSet<UserSkill> UserSkill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Module>()
                .HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseId);
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
     .HasKey(u => u.Id);

            modelBuilder.Entity<Student>()
                .HasBaseType<User>();

            modelBuilder.Entity<Instructor>()
                .HasBaseType<User>();

            modelBuilder.Entity<Admin>()
                .HasBaseType<User>();

        }

    }
}
