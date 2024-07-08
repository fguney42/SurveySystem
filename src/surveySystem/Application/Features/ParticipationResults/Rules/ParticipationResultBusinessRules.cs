using Application.Features.ParticipationResults.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ParticipationResults.Rules;

public class ParticipationResultBusinessRules : BaseBusinessRules
{
    private readonly IParticipationResultRepository _participationResultRepository;
    private readonly ILocalizationService _localizationService;

    public ParticipationResultBusinessRules(IParticipationResultRepository participationResultRepository, ILocalizationService localizationService)
    {
        _participationResultRepository = participationResultRepository;
        _localizationService = localizationService;
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

    public async Task<ParticipationResult?> CheckIfUpdateOrCreateParticipationResult(Guid surveyId)
    {
        ParticipationResult? participationResult = await _participationResultRepository.GetAsync(pr => pr.SurveyId.Equals(surveyId));
        if (participationResult is not null)
        {
            participationResult.Result = await _participationResultRepository.IncrementParticipationResult(participationResult.Id);
            await _participationResultRepository.UpdateAsync(participationResult);
            return participationResult;
        }
            return await _participationResultRepository.AddAsync(new ParticipationResult() { SurveyId = surveyId});
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