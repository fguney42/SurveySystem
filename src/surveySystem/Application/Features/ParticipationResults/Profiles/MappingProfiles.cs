using Application.Features.ParticipationResults.Commands.Create;
using Application.Features.ParticipationResults.Commands.Delete;
using Application.Features.ParticipationResults.Commands.Update;
using Application.Features.ParticipationResults.Queries.GetById;
using Application.Features.ParticipationResults.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ParticipationResults.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ParticipationResult, CreateParticipationResultCommand>().ReverseMap();
        CreateMap<ParticipationResult, CreatedParticipationResultResponse>().ReverseMap();
        CreateMap<ParticipationResult, UpdateParticipationResultCommand>().ReverseMap();
        CreateMap<ParticipationResult, UpdatedParticipationResultResponse>().ReverseMap();
        CreateMap<ParticipationResult, DeleteParticipationResultCommand>().ReverseMap();
        CreateMap<ParticipationResult, DeletedParticipationResultResponse>().ReverseMap();
        CreateMap<ParticipationResult, GetByIdParticipationResultResponse>().ReverseMap();
        CreateMap<ParticipationResult, GetListParticipationResultListItemDto>().ReverseMap();
        CreateMap<IPaginate<ParticipationResult>, GetListResponse<GetListParticipationResultListItemDto>>().ReverseMap();
    }
}