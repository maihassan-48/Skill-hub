using AutoMapper;
using Skill_Hub.Configurations;
using Skill_Hub.Dtos;
using Skill_Hub.Enums;
using Skill_Hub.Models;
using Skill_Hub.Services.Interfaces;

namespace Skill_Hub.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }
        public async Task<List<UserResponseDTO>> GetAll()
        {
            var users = await _unitOfWork.userRepository.GetAllUsers();
            return _mapper.Map<List<UserResponseDTO>>(users);
        }

        public async Task<UserResponseDTO?> GetById(int id)
        {
            var user = await _unitOfWork.userRepository.GetById(id);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO?> GetByEmail(string email)
        {
            var user = await _unitOfWork.userRepository.GetByEmail(email);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO?> GetByName(string name)
        {
            var user = await _unitOfWork.userRepository.GetByName(name);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task Update(UserRequestDTO userDto, int id)
        {
            User user = _mapper.Map<User>(userDto);

            if (await _unitOfWork.userRepository.UpdateUser(user, id) == 0)
            {
                throw new Exception("User not found");
            }
            _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            if (await _unitOfWork.userRepository.DeleteUser(id) == 0)
            {
                throw new Exception("User not found");
            }
            _unitOfWork.Save();
        }

        public async Task<SignInResponseDTO> SignIn(SignInRequestDTO signInRequestDto)
        {
            var user = await _unitOfWork.userRepository.SignIn(signInRequestDto.Email, signInRequestDto.Password);

            if (user != null)
            {
                string token = _jwtService.GenerateToken(user, user.Role);
                return new SignInResponseDTO
                {
                    Token = token,
                    Expiration = DateTime.UtcNow.AddHours(1),
                    UserId = user.Id,
                    Name = user.Name,
                    Role = user.Role.ToString()
                };
            }
            else
            {
                throw new Exception("Invalid email or password");
            }
        }
    }
}
