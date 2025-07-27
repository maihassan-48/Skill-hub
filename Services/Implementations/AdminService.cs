using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Services.Interfaces
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper, JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<SignInResponseDTO> CreateAdminAsync(AdminRequestDTO adminDTO)
        {
            var admin = _mapper.Map<Admin>(adminDTO);
            await _unitOfWork.AdminRepository.AddAdminAsync(admin);
            _unitOfWork.Save();

            var token = _jwtService.GenerateToken(admin.User, admin.User.Role);
            return await Task.FromResult(new SignInResponseDTO
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1),
                UserId = admin.Id,
                Name = admin.User.Name,
                Role = admin.User.Role.ToString()
            });
        }

        public async Task<IEnumerable<AdminResponseDTO>> GetAllAdminsAsync()
        {
            var admins = await _unitOfWork.AdminRepository.GetAllAdminsAsync();
            return _mapper.Map<IEnumerable<AdminResponseDTO>>(admins);
        }

        public async Task<AdminResponseDTO?> GetAdminByIdAsync(int id)
        {
            var admins = await _unitOfWork.AdminRepository.GetAdminByIdAsync(id);
            return _mapper.Map<AdminResponseDTO>(admins);
        }

        public async Task UpdateAdminAsync(int id, AdminRequestDTO adminDTO)
        {
            var admin = _mapper.Map<Admin>(adminDTO);

            int rowsAffected = await _unitOfWork.AdminRepository.UpdateAdminAsync(id, admin);

            if (rowsAffected == 0)
            {
                throw new Exception("Admin not found");
            }

            _unitOfWork.Save();
        }

        public async Task DeleteAdminAsync(int id)
        {
            int rowsAffected =  await _unitOfWork.AdminRepository.DeleteAdminAsync(id);

            if (rowsAffected == 0)
            {
                throw new Exception("Admin not found");
            }

            _unitOfWork.Save();
        }
    }
}
