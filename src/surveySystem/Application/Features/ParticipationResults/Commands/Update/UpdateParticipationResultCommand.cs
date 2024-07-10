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

namespace Application.Features.ParticipationResults.Commands.Update;

public class UpdateParticipationResultCommand : IRequest<UpdatedParticipationResultResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int Result { get; set; }
    public Guid SurveyId { get; set; }

    public string[] Roles => [Admin, Write, ParticipationResultsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetParticipationResults"];

    public class UpdateParticipationResultCommandHandler : IRequestHandler<UpdateParticipationResultCommand, UpdatedParticipationResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IParticipationResultRepository _participationResultRepository;
        private readonly ParticipationResultBusinessRules _participationResultBusinessRules;

        public UpdateParticipationResultCommandHandler(IMapper mapper, IParticipationResultRepository participationResultRepository,
                                         ParticipationResultBusinessRules participationResultBusinessRules)
        {
            _mapper = mapper;
            _participationResultRepository = participationResultRepository;
            _participationResultBusinessRules = participationResultBusinessRules;
        }

        public async Task<UpdatedParticipationResultResponse> Handle(UpdateParticipationResultCommand request, CancellationToken cancellationToken)
        {
            ParticipationResult? participationResult = await _participationResultRepository.GetAsync(predicate: pr => pr.Id == request.Id, cancellationToken: cancellationToken);
            await _participationResultBusinessRules.ParticipationResultShouldExistWhenSelected(participationResult);
            participationResult = _mapper.Map(request, participationResult);

            await _participationResultRepository.UpdateAsync(participationResult!);

            UpdatedParticipationResultResponse response = _mapper.Map<UpdatedParticipationResultResponse>(participationResult);
            return response;
        }
    }
}