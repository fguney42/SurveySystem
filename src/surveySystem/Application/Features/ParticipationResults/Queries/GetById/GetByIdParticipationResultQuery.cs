using Application.Features.ParticipationResults.Constants;
using Application.Features.ParticipationResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ParticipationResults.Constants.ParticipationResultsOperationClaims;

namespace Application.Features.ParticipationResults.Queries.GetById;

public class GetByIdParticipationResultQuery : IRequest<GetByIdParticipationResultResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdParticipationResultQueryHandler : IRequestHandler<GetByIdParticipationResultQuery, GetByIdParticipationResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IParticipationResultRepository _participationResultRepository;
        private readonly ParticipationResultBusinessRules _participationResultBusinessRules;

        public GetByIdParticipationResultQueryHandler(IMapper mapper, IParticipationResultRepository participationResultRepository, ParticipationResultBusinessRules participationResultBusinessRules)
        {
            _mapper = mapper;
            _participationResultRepository = participationResultRepository;
            _participationResultBusinessRules = participationResultBusinessRules;
        }

        public async Task<GetByIdParticipationResultResponse> Handle(GetByIdParticipationResultQuery request, CancellationToken cancellationToken)
        {
            ParticipationResult? participationResult = await _participationResultRepository.GetAsync(predicate: pr => pr.Id == request.Id, cancellationToken: cancellationToken);
            await _participationResultBusinessRules.ParticipationResultShouldExistWhenSelected(participationResult);

            GetByIdParticipationResultResponse response = _mapper.Map<GetByIdParticipationResultResponse>(participationResult);
            return response;
        }
    }
}