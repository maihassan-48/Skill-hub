using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorService _instructorService;

        public InstructorService(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            return await _instructorService.GetAllInstructorsAsync();
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
        {
            return await _instructorService.GetInstructorByIdAsync(id);
        }
    }
}
