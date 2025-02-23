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

namespace Application.Features.Surveys.Commands.Update;

public class UpdateSurveyCommand : IRequest<UpdatedSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string[] Roles => [Admin, Write, SurveysOperationClaims.Update, OperationClaimsOperationClaims.MemberRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSurveys"];

    public class UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommand, UpdatedSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly SurveyBusinessRules _surveyBusinessRules;

        public UpdateSurveyCommandHandler(IMapper mapper, ISurveyRepository surveyRepository,
                                         SurveyBusinessRules surveyBusinessRules)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _surveyBusinessRules = surveyBusinessRules;
        }

        public async Task<UpdatedSurveyResponse> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            Survey? survey = await _surveyRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyBusinessRules.SurveyShouldExistWhenSelected(survey);
            survey = _mapper.Map(request, survey);

            await _surveyRepository.UpdateAsync(survey!);

            UpdatedSurveyResponse response = _mapper.Map<UpdatedSurveyResponse>(survey);
            return response;
        }
    }
}