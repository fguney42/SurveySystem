using Application.Features.Surveys.Commands.Create;
using Application.Features.Surveys.Commands.Delete;
using Application.Features.Surveys.Commands.Update;
using Application.Features.Surveys.Queries.GetById;
using Application.Features.Surveys.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Surveys.Queries;
using Application.Features.Members.Queries;

namespace Application.Features.Surveys.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Survey, CreateSurveyCommand>().ReverseMap();
        CreateMap<Survey, CreatedSurveyResponse>().ReverseMap();
        CreateMap<Survey, UpdateSurveyCommand>().ReverseMap();
        CreateMap<Survey, UpdatedSurveyResponse>().ReverseMap();
        CreateMap<Survey, DeleteSurveyCommand>().ReverseMap();
        CreateMap<Survey, DeletedSurveyResponse>().ReverseMap();
        CreateMap<Survey, GetByIdSurveyResponse>().ReverseMap();
        CreateMap<Survey, GetListSurveyListItemDto>().ReverseMap();
        CreateMap<Member,GetMemberFromAuthResponse>().ReverseMap();
        CreateMap<IPaginate<Survey>, GetListResponse<GetListSurveyListItemDto>>().ReverseMap();
    }
}