using Application.Features.Surveys.Constants;
using Application.Features.Surveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Surveys.Constants.SurveysOperationClaims;
using Application.Features.OperationClaims.Constants;

namespace Application.Features.Surveys.Queries.GetById;

public class GetByIdSurveyQuery : IRequest<GetByIdSurveyResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read,OperationClaimsOperationClaims.MemberRole];

    public class GetByIdSurveyQueryHandler : IRequestHandler<GetByIdSurveyQuery, GetByIdSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly SurveyBusinessRules _surveyBusinessRules;

        public GetByIdSurveyQueryHandler(IMapper mapper, ISurveyRepository surveyRepository, SurveyBusinessRules surveyBusinessRules)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _surveyBusinessRules = surveyBusinessRules;
        }

        public async Task<GetByIdSurveyResponse> Handle(GetByIdSurveyQuery request, CancellationToken cancellationToken)
        {
            Survey? survey = await _surveyRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyBusinessRules.SurveyShouldExistWhenSelected(survey);

            GetByIdSurveyResponse response = _mapper.Map<GetByIdSurveyResponse>(survey);
            return response;
        }
    }
}