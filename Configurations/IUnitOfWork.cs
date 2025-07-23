using Skill_Hub.Repositories.Interfaces;

namespace Skill_Hub.Configurations
{
    public interface IUnitOfWork
    {
        public IInstructorRepository instructorRepository { get; }
        public IUserRepository userRepository { get; }
        public void Save();
    }
}