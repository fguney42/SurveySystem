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

namespace Application.Features.Surveys.Commands.Create;

public class CreateSurveyCommand : IRequest<CreatedSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Title { get; set; }

    public string[] Roles => [Admin, Write, SurveysOperationClaims.Create, OperationClaimsOperationClaims.MemberRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSurveys"];

    public class CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommand, CreatedSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly SurveyBusinessRules _surveyBusinessRules;

        public CreateSurveyCommandHandler(IMapper mapper, ISurveyRepository surveyRepository,
                                         SurveyBusinessRules surveyBusinessRules)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _surveyBusinessRules = surveyBusinessRules;
        }

        public async Task<CreatedSurveyResponse> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            await _surveyBusinessRules.CheckIfSurveyAlreadyExists(request.Title);
            Survey survey = _mapper.Map<Survey>(request);
            
            await _surveyRepository.AddAsync(survey);

            CreatedSurveyResponse response = _mapper.Map<CreatedSurveyResponse>(survey);
            return response;
        }
    }
}