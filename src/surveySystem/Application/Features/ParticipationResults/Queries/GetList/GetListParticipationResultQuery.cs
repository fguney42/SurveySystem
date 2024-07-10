using Application.Features.ParticipationResults.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ParticipationResults.Constants.ParticipationResultsOperationClaims;

namespace Application.Features.ParticipationResults.Queries.GetList;

public class GetListParticipationResultQuery : IRequest<GetListResponse<GetListParticipationResultListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }


    public bool BypassCache { get; }
    public string? CacheKey => $"GetListParticipationResults({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetParticipationResults";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListParticipationResultQueryHandler : IRequestHandler<GetListParticipationResultQuery, GetListResponse<GetListParticipationResultListItemDto>>
    {
        private readonly IParticipationResultRepository _participationResultRepository;
        private readonly IMapper _mapper;

        public GetListParticipationResultQueryHandler(IParticipationResultRepository participationResultRepository, IMapper mapper)
        {
            _participationResultRepository = participationResultRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListParticipationResultListItemDto>> Handle(GetListParticipationResultQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ParticipationResult> participationResults = await _participationResultRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListParticipationResultListItemDto> response = _mapper.Map<GetListResponse<GetListParticipationResultListItemDto>>(participationResults);
            return response;
        }
    }
}