using Application.Features.Participations.Constants;
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

namespace Application.Features.Participations.Commands.Delete;

public class DeleteParticipationCommand : IRequest<DeletedParticipationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ParticipationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetParticipations"];

    public class DeleteParticipationCommandHandler : IRequestHandler<DeleteParticipationCommand, DeletedParticipationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IParticipationRepository _participationRepository;
        private readonly ParticipationBusinessRules _participationBusinessRules;

        public DeleteParticipationCommandHandler(IMapper mapper, IParticipationRepository participationRepository,
                                         ParticipationBusinessRules participationBusinessRules)
        {
            _mapper = mapper;
            _participationRepository = participationRepository;
            _participationBusinessRules = participationBusinessRules;
        }

        public async Task<DeletedParticipationResponse> Handle(DeleteParticipationCommand request, CancellationToken cancellationToken)
        {
            Participation? participation = await _participationRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _participationBusinessRules.ParticipationShouldExistWhenSelected(participation);

            await _participationRepository.DeleteAsync(participation!);

            DeletedParticipationResponse response = _mapper.Map<DeletedParticipationResponse>(participation);
            return response;
        }
    }
}