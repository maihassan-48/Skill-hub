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
        private IStudentRepository _studentRepository;
        private IAdminRepository _adminRepository;

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

        public IStudentRepository StudentRepository
        {
            get
            {
                return _studentRepository = _studentRepository ?? new StudentRepository(_context);
            }
        }

        public IAdminRepository AdminRepository
        {
            get
            {
                return _adminRepository = _adminRepository ?? new AdminRepository(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}