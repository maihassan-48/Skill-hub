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

        }
    }
}
