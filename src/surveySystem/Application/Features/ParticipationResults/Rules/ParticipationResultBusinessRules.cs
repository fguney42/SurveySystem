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
    public async Task IncreaseCountAccordingToAnswer(string answer, ParticipationResult participationResult)
    {
        if (answer is ParticipationResultsBusinessMessages.AnswerYes)
        {
            participationResult.TotalYesAnswer++;
        }
        else
        {
            participationResult.TotalYesAnswer++;
        }
    }
    public async Task<ParticipationResult?> CheckIfUpdateOrCreateParticipationResult(Guid surveyId,string answer)
    {
        ParticipationResult? participationResult = await _participationResultRepository.GetAsync(pr => pr.SurveyId.Equals(surveyId));
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
            participationResult = new ParticipationResult() { SurveyId = surveyId};
            await IncreaseCountAccordingToAnswer(answer, participationResult);
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