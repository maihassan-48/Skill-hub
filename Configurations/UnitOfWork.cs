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
        
        public IStudentRepository studentRepository
        {
            get
            {
                return _studentRepository = _studentRepository ?? new StudentRepository(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}