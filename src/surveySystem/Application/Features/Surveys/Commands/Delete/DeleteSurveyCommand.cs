using Application.Features.Surveys.Constants;
using Application.Features.Surveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Surveys.Constants.SurveysOperationClaims;
using Application.Features.OperationClaims.Constants;
using Application.Services.ParticipationResults;
using Application.Services.Participations;

namespace Application.Features.Surveys.Commands.Delete;

public class DeleteSurveyCommand : IRequest<DeletedSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string[] Roles => [Admin, Write, SurveysOperationClaims.Delete, OperationClaimsOperationClaims.MemberRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSurveys","GetParticipationResults","GetParticipations"];

    public class DeleteSurveyCommandHandler : IRequestHandler<DeleteSurveyCommand, DeletedSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly IParticipationResultService _participationResultService;
        private readonly IParticipationService _participationService;
        private readonly SurveyBusinessRules _surveyBusinessRules;

        public DeleteSurveyCommandHandler(IMapper mapper, ISurveyRepository surveyRepository,
                                         SurveyBusinessRules surveyBusinessRules, IParticipationResultService participationResultService, IParticipationService participationService)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _surveyBusinessRules = surveyBusinessRules;
            _participationResultService = participationResultService;
            _participationService = participationService;
        }

        public async Task<DeletedSurveyResponse> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            Survey? survey = await _surveyRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyBusinessRules.SurveyShouldExistWhenSelected(survey);

            await _surveyBusinessRules.DeleteIfHasRelations(request.Id);
            await _surveyRepository.DeleteAsync(survey!);

            DeletedSurveyResponse response = _mapper.Map<DeletedSurveyResponse>(survey);
            return response;
        }
    }
}