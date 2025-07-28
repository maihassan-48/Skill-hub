using AutoMapper;
using Skill_Hub.Dtos;
using Skill_Hub.Models;

namespace Skill_Hub.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<EnrollmentRequestDTO, Enrollment>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.CompletionDate, opt => opt.MapFrom(src => src.CompletionDate))
                .ReverseMap();

            CreateMap<Enrollment, EnrollmentResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.CompletionDate, opt => opt.MapFrom(src => src.CompletionDate))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Course.Description))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Course.Category.Name))
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Course.Instructor.User.Name))
                .ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => src.EnrollmentDate))
                .ForMember(dest => dest.ProgressPercentage, opt => opt.MapFrom(src => src.ProgressPercentage));
        }
    }
}
