using AutoMapper;
using Skill_Hub.Dtos;
using Skill_Hub.Models;
using SkillHub.DTOs;

namespace Skill_Hub.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserRequestDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<Instructor, InstructorRequestDTO>().ReverseMap();
            CreateMap<Instructor, InstructorResponseDTO>().ReverseMap();
        }
    }
}
