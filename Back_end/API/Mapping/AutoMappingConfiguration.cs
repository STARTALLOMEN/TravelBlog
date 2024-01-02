using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class AutoMappingConfiguration : Profile
    {
        public AutoMappingConfiguration()
        {
            CreateMap<Destination, DestinationDto>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                    .ForMember(dest => dest.ProvinceOrAreaOrPrArea, opt => opt.MapFrom(src => src.ProvinceOrAreaOrPrArea.ToString()))
                    .ForMember(dest => dest.NameProvince, opt => opt.MapFrom(src => src.Province.Name));

            CreateMap<DestinationAdd, Destination>()
                    .ForMember(dest => dest.ProvinceOrAreaOrPrArea, opt => opt.MapFrom(src => src.ProvinceOrAreaOrPrArea.ToString()));
            // .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse(typeof(StatusDestination), src.Status)));
            CreateMap<Destination, DestinationAdd>();
            // .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDto, Blog>();
            CreateMap<BlogAdd, Blog>();

            CreateMap<PlanAdd, Plan>();
            CreateMap<Plan, PlanDto>()
                    .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.User))
                    .ForMember(dest => dest.DestinationDtos, opt => opt.MapFrom(src => src.PlanDestinations.Select(pd => pd.Destination)));

            CreateMap<ImageQuestion, ImageQuestionDto>();
            // CreateMap<Destination, DesDto>();

            CreateMap<QuestionDestination, DestinationDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Destination.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Destination.Name));

            CreateMap<Question, QuestionDto>()
                    .ForMember(dest => dest.ImageQuestionsDto, opt => opt.MapFrom(src => src.ImageQuestions))
                    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                    .ForMember(dest => dest.DesDto, opt => opt.MapFrom(src => src.QuestionDestinations.Select(qd => qd.Destination)));

            CreateMap<QuestionDto, Question>();
            CreateMap<QuestionAdd, Question>();
            CreateMap<ReviewDestinationAdd, ReviewDestination>();

            CreateMap<ImageShare, ImageShareDto>();
            CreateMap<ImageShareDto, ImageShare>();
            CreateMap<ImageShareAdd, ImageShare>();

            CreateMap<Province, ProvinceDto>();
            // CreateMap<Dictrict,DictrictDto>();
            // CreateMap<Ward,WardDto>();
        }
    }
}