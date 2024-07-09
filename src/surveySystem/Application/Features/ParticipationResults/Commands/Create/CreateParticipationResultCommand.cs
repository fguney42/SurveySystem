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
using NArchitecture.Core.Application.Requests;
using Application.Features.OperationClaims.Constants;

namespace Application.Features.ParticipationResults.Commands.Create;

public class CreateParticipationResultCommand : IRequest<CreatedParticipationResultResponse>, ISecuredRequest,ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid SurveyId { get; set; }
    public string Answer {  get; set; }
    public string[] Roles => [Admin, Write, ParticipationResultsOperationClaims.Create,OperationClaimsOperationClaims.MemberRole];

    public bool BypassCache { get; }
    public string[]? CacheGroupKey => ["GetParticipationResults"];
    public string? CacheKey { get; set; }

    public class CreateParticipationResultCommandHandler : IRequestHandler<CreateParticipationResultCommand, CreatedParticipationResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IParticipationResultRepository _participationResultRepository;
        private readonly ParticipationResultBusinessRules _participationResultBusinessRules;

        public CreateParticipationResultCommandHandler(IMapper mapper, IParticipationResultRepository participationResultRepository,
                                         ParticipationResultBusinessRules participationResultBusinessRules)
        {
            _mapper = mapper;
            _participationResultRepository = participationResultRepository;
            _participationResultBusinessRules = participationResultBusinessRules;
        }

        public async Task<CreatedParticipationResultResponse> Handle(CreateParticipationResultCommand request, CancellationToken cancellationToken)
        {
            ParticipationResult participationResult = _mapper.Map<ParticipationResult>(request);

            await _participationResultBusinessRules.CheckIfUpdateOrCreateParticipationResult(request.SurveyId,request.Answer);

            CreatedParticipationResultResponse response = _mapper.Map<CreatedParticipationResultResponse>(participationResult);
            return response;
        }
    }
}