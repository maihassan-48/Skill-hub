using AutoMapper;
using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserRequestDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<Instructor, InstructorRequestDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.User.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.User.Role))
                .ReverseMap();
            CreateMap<Instructor, InstructorResponseDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.User.Role))
                .ReverseMap();
        }
    }
}
