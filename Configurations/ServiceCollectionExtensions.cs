using Microsoft.AspNetCore.DataProtection;
using Skill_Hub.Repositories.Implementations;
using Skill_Hub.Repositories.Interfaces;
using Skill_Hub.Services.Implementations;
using Skill_Hub.Services.Interfaces;
using UserSkill_Hub.Services.Interfaces;

namespace Skill_Hub.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(
            this IServiceCollection services)
        {
            services.AddScoped<JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminService, AdminService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();

            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<IUserSkillRepository, UserSkillRepository>();

            // Register services
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IModuleService, ModuleService>();


            services.AddScoped<JwtService>();

            return services;
        }
    }
}