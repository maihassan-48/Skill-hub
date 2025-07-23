using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;
using Skill_Hub.Configurations;

namespace Skill_Hub.Services.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstructorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            return await _unitOfWork.instructorRepository.GetAllInstructorsAsync();
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
        {
            return await _unitOfWork.instructorRepository.GetInstructorByIdAsync(id);
        }
    }
}
