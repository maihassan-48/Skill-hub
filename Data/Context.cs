using Microsoft.EntityFrameworkCore;
using Skill_Hub.Models;

namespace Skill_Hub.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                        .HasMany(c => c.Skills)
                        .WithMany(s => s.Students)
                        .UsingEntity<UserSkill>();

            modelBuilder.Entity<User>()
                        .HasOne(a => a.Admin)
                        .WithOne(u => u.User)
                        .HasForeignKey<Admin>();

            modelBuilder.Entity<User>()
                        .HasOne(s => s.Student)
                        .WithOne(u => u.User)
                        .HasForeignKey<Student>();

            modelBuilder.Entity<User>()
                        .HasOne(i => i.Instructor)
                        .WithOne(u => u.User)
                        .HasForeignKey<Instructor>();

        }

    }
}
