using Application.Features.ParticipationResults.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;

namespace Application.Services.ParticipationResults;

public class ParticipationResultManager : IParticipationResultService
{
    private readonly IParticipationResultRepository _participationResultRepository;
    private readonly ParticipationResultBusinessRules _participationResultBusinessRules;

    public ParticipationResultManager(IParticipationResultRepository participationResultRepository, ParticipationResultBusinessRules participationResultBusinessRules)
    {
        _participationResultRepository = participationResultRepository;
        _participationResultBusinessRules = participationResultBusinessRules;
    }

    public async Task<ParticipationResult?> GetAsync(
        Expression<Func<ParticipationResult, bool>> predicate,
        Func<IQueryable<ParticipationResult>, IIncludableQueryable<ParticipationResult, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ParticipationResult? participationResult = await _participationResultRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return participationResult;
    }

    public async Task<IPaginate<ParticipationResult>?> GetListAsync(
        Expression<Func<ParticipationResult, bool>>? predicate = null,
        Func<IQueryable<ParticipationResult>, IOrderedQueryable<ParticipationResult>>? orderBy = null,
        Func<IQueryable<ParticipationResult>, IIncludableQueryable<ParticipationResult, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ParticipationResult> participationResultList = await _participationResultRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return participationResultList;
    }

    public async Task<ParticipationResult> AddAsync(ParticipationResult participationResult)
    {
        ParticipationResult addedParticipationResult = await _participationResultRepository.AddAsync(participationResult);

        return addedParticipationResult;
    }

    //public async Task<ParticipationResult> UpdateOrCreateByParticipationResult(Guid surveyId)
    //{
    //    ParticipationResult? participationResult = await _participationResultBusinessRules.CheckIfUpdateOrCreateParticipationResult(surveyId);

    //    return participationResult;
    //}
    public async Task<ParticipationResult> UpdateAsync(ParticipationResult participationResult)
    {
        ParticipationResult updatedParticipationResult = await _participationResultRepository.UpdateAsync(participationResult);

        return updatedParticipationResult;
    }

    public async Task<ParticipationResult> DeleteAsync(ParticipationResult participationResult, bool permanent = false)
    {
        ParticipationResult deletedParticipationResult = await _participationResultRepository.DeleteAsync(participationResult);

        return deletedParticipationResult;
    }
}
