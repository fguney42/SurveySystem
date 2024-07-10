using Application.Features.ParticipationResults.Constants;
using Application.Features.ParticipationResults.Constants;
using Application.Features.ParticipationResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ParticipationResults.Constants.ParticipationResultsOperationClaims;

namespace Application.Features.ParticipationResults.Commands.Delete;

public class DeleteParticipationResultCommand : IRequest<DeletedParticipationResultResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ParticipationResultsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetParticipationResults"];

    public class DeleteParticipationResultCommandHandler : IRequestHandler<DeleteParticipationResultCommand, DeletedParticipationResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IParticipationResultRepository _participationResultRepository;
        private readonly ParticipationResultBusinessRules _participationResultBusinessRules;

        public DeleteParticipationResultCommandHandler(IMapper mapper, IParticipationResultRepository participationResultRepository,
                                         ParticipationResultBusinessRules participationResultBusinessRules)
        {
            _mapper = mapper;
            _participationResultRepository = participationResultRepository;
            _participationResultBusinessRules = participationResultBusinessRules;
        }

        public async Task<DeletedParticipationResultResponse> Handle(DeleteParticipationResultCommand request, CancellationToken cancellationToken)
        {
            ParticipationResult? participationResult = await _participationResultRepository.GetAsync(predicate: pr => pr.Id == request.Id, cancellationToken: cancellationToken);
            await _participationResultBusinessRules.ParticipationResultShouldExistWhenSelected(participationResult);

            await _participationResultRepository.DeleteAsync(participationResult!);

            DeletedParticipationResultResponse response = _mapper.Map<DeletedParticipationResultResponse>(participationResult);
            return response;
        }
    }
}