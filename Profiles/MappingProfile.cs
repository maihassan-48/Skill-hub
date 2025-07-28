using AutoMapper;
using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateCourseDto, Course>();
            CreateMap<CreateModuleDto, Module>();

            CreateMap<Category, CategoryResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


            CreateMap<Course, CourseResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId));


            CreateMap<Module, ModuleResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId));

            CreateMap<SkillRequestDTO, Skill>().ReverseMap();
            CreateMap<SkillResponseDTO, Skill>().ReverseMap();

            CreateMap<UserSkillDTO, UserSkill>().ReverseMap();
        }
    }
}
