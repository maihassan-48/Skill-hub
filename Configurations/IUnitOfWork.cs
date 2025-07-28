using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Configurations
{
    public interface IUnitOfWork
    {
        public IInstructorRepository instructorRepository { get; }
        public IUserRepository userRepository { get; }
        public IEnrollmentRepository enrollmentRepository { get; }
        public IStudentRepository StudentRepository{get; }
        public ICourseRepository CourseRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IModuleRepository ModuleRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IAdminRepository AdminRepository { get; }
        public void Save();
    }
}