using Application.Features.Surveys.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Services.ParticipationResults;
using Application.Services.Questions;
using Application.Services.Participations;
using Microsoft.AspNetCore.Http.Features;

namespace Application.Features.Surveys.Rules;

public class SurveyBusinessRules : BaseBusinessRules
{
    private readonly ISurveyRepository _surveyRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IParticipationResultService _participationResultService;
    private readonly IQuestionService _questionService;
    private readonly IParticipationService _participationService;

    public SurveyBusinessRules(ISurveyRepository surveyRepository, ILocalizationService localizationService, IParticipationResultService participationResultService, IQuestionService questionService, IParticipationService participationService)
    {
        _surveyRepository = surveyRepository;
        _localizationService = localizationService;
        _participationResultService = participationResultService;
        _questionService = questionService;
        _participationService = participationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SurveysBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SurveyShouldExistWhenSelected(Survey? survey)
    {
        if (survey == null)
            await throwBusinessException(SurveysBusinessMessages.SurveyNotExists);
    }
    public async Task DeleteIfHasRelations(Guid id)
    {
        var participationResults = await _participationResultService.GetListAsync(pr => pr.SurveyId.Equals(id));
        var participations = await _participationService.GetListAsync(p => p.SurveyId.Equals(id));
        var questions = await _questionService.GetListAsync(q => q.SurveyId.Equals(id));

        if (participationResults.Items.Count > 0)
            await _participationResultService.DeleteRangeAsync(participationResults.Items);

        if (participations.Items.Count > 0)
            await _participationService.DeleteRangeAsync(participations.Items);

        if (questions.Items.Count > 0)
            await _questionService.DeleteRangeAsync(questions.Items);  
    }
    public async Task CheckIfSurveyAlreadyExists(string title)
    {
       Survey? survey =  await _surveyRepository.GetAsync(s => s.Title.Equals(title));
        if (survey is not null)
            await throwBusinessException(SurveysBusinessMessages.SurveyAlreadyExists);
    }

    public async Task SurveyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Survey? survey = await _surveyRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SurveyShouldExistWhenSelected(survey);
    }
}