using Application.Features.Participations.Constants;
using Application.Features.Participations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Participations.Constants.ParticipationsOperationClaims;
using Application.Features.OperationClaims.Constants;

namespace Application.Features.Participations.Commands.Create;

public class CreateParticipationCommand : IRequest<CreatedParticipationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Answer { get; set; }
    public Guid MemberId { get; set; }
    public Guid SurveyId { get; set; }

    public string[] Roles => [Admin, Write, ParticipationsOperationClaims.Create, OperationClaimsOperationClaims.MemberRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetParticipations"];

    public class CreateParticipationCommandHandler : IRequestHandler<CreateParticipationCommand, CreatedParticipationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IParticipationRepository _participationRepository;
        private readonly ParticipationBusinessRules _participationBusinessRules;

        public CreateParticipationCommandHandler(IMapper mapper, IParticipationRepository participationRepository,
                                         ParticipationBusinessRules participationBusinessRules)
        {
            _mapper = mapper;
            _participationRepository = participationRepository;
            _participationBusinessRules = participationBusinessRules;
        }

        public async Task<CreatedParticipationResponse> Handle(CreateParticipationCommand request, CancellationToken cancellationToken)
        {
            Participation participation = _mapper.Map<Participation>(request);

            await _participationRepository.AddAsync(participation);

            CreatedParticipationResponse response = _mapper.Map<CreatedParticipationResponse>(participation);
            return response;
        }
    }
}