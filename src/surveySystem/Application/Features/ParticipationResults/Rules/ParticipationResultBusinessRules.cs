using Application.Features.ParticipationResults.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Participations.Constants;
using MailKit;

namespace Application.Features.ParticipationResults.Rules;

public class ParticipationResultBusinessRules : BaseBusinessRules
{
    private readonly IParticipationResultRepository _participationResultRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IParticipationRepository _participationRepository;

    public ParticipationResultBusinessRules(IParticipationResultRepository participationResultRepository, ILocalizationService localizationService, IParticipationRepository participationRepository)
    {
        _participationResultRepository = participationResultRepository;
        _localizationService = localizationService;
        _participationRepository = participationRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ParticipationResultsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ParticipationResultShouldExistWhenSelected(ParticipationResult? participationResult)
    {
        if (participationResult == null)
            await throwBusinessException(ParticipationResultsBusinessMessages.ParticipationResultNotExists);
    }
    public async Task IncreaseCountAccordingToAnswer(string answer, ParticipationResult participationResult, bool isNew=false)
    {
        if (answer is ParticipationResultsBusinessMessages.AnswerYes)
        {
            participationResult.TotalYesAnswer++;
            if (isNew)
            participationResult.PercentYes = 100;
        }
        else
        {
            if (isNew)
                participationResult.PercentNo = 100;
            participationResult.TotalNoAnswer++;
        }
    }
    public async Task<ParticipationResult?> CheckIfUpdateOrCreateParticipationResult(Guid surveyId,Guid?questionId,string answer)
    {
        ParticipationResult? participationResult = await _participationResultRepository.GetAsync(pr => pr.SurveyId.Equals(surveyId) && pr.QuestionId.Equals(questionId));
        if (participationResult is not null)
        {
            participationResult.Result = await _participationResultRepository.IncrementParticipationResult(participationResult.Id);
            await IncreaseCountAccordingToAnswer(answer,participationResult);
            participationResult.PercentYes = await _participationResultRepository.CalculatePercentYes(participationResult.TotalNoAnswer, participationResult.TotalYesAnswer);
            participationResult.PercentNo = await _participationResultRepository.CalculatePercentNo(participationResult.TotalNoAnswer, participationResult.TotalYesAnswer);
            await _participationResultRepository.UpdateAsync(participationResult);
            return participationResult;
        }
        else
        {
            participationResult = new ParticipationResult() { SurveyId = surveyId,QuestionId = questionId};
            await IncreaseCountAccordingToAnswer(answer, participationResult,true);
            return await _participationResultRepository.AddAsync(participationResult);   
        }
            
    }       
    public async Task ParticipationResultIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ParticipationResult? participationResult = await _participationResultRepository.GetAsync(
            predicate: pr => pr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ParticipationResultShouldExistWhenSelected(participationResult);
    }
}