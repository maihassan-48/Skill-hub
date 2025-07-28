using Skill_Hub.Data;
using Skill_Hub.Repositories.Implementations;
using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Configurations
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context;
        private IInstructorRepository _instructorRepository;
        private IUserRepository _userRepository;
        private IEnrollmentRepository _enrollmentRepository;
        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;
        private ICategoryRepository _categoryRepository;
        private IModuleRepository _moduleRepository;
        private IAdminRepository _adminRepository;
        private ISkillRepository _skillRepository;
        private IUserSkillRepository _userSkillRepository;


        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public IInstructorRepository instructorRepository
        {
            get
            {
                return _instructorRepository = _instructorRepository ?? new InstructorRepository(_context);
            }
        }

        public IUserRepository userRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public IEnrollmentRepository enrollmentRepository
        {
            get
            {
                return _enrollmentRepository = _enrollmentRepository ?? new EnrollmentRepository(_context);
            }
        }
        
        public IStudentRepository StudentRepository
        {
            get
            {
                return _studentRepository = _studentRepository ?? new StudentRepository(_context);
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                return _courseRepository = _courseRepository ?? new CourseRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
            }
        }

        public IModuleRepository ModuleRepository
        {
            get
            {
                return _moduleRepository = _moduleRepository ?? new ModuleRepository(_context);
            }
        }

        public IAdminRepository AdminRepository
        {
            get
            {
                return _adminRepository = _adminRepository ?? new AdminRepository(_context);
            }
        }

        public ISkillRepository SkillRepository
        {
            get
            {
                return _skillRepository = _skillRepository ?? new SkillRepository(_context);
            }
        }
        public IUserSkillRepository UserSkillRepository
        {
            get
            {
                return _userSkillRepository = _userSkillRepository ?? new UserSkillRepository(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}