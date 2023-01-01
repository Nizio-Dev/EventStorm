﻿using AutoMapper;
using EventStorm.Application.Requests;
using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;
using EventStorm.Web.Helpers;
using System.Security.Claims;

namespace EventStorm.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClaimsPrincipal, Attender>()
                .ForMember(dest => dest.AuthProviderId, opt => opt.MapFrom(src => src.GetAuthProviderId()))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.GetName()))
                .ForMember(dest => dest.Email,opt => opt.MapFrom(src => src.GetEmail()));

            CreateMap<Attender, AttenderDto>();

            CreateMap<Meeting, MeetingDto>();

            CreateMap<CreateMeetingDto, Meeting>();

            CreateMap<Attendance, MeetingAttendanceDto>();

            CreateMap<CreateCategoryDto, Category>();

            CreateMap<Category, CategoryDto>();
		}
    }
}