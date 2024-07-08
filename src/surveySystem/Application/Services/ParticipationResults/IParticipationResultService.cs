using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ParticipationResults;

public interface IParticipationResultService
{
    Task<ParticipationResult?> GetAsync(
        Expression<Func<ParticipationResult, bool>> predicate,
        Func<IQueryable<ParticipationResult>, IIncludableQueryable<ParticipationResult, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ParticipationResult>?> GetListAsync(
        Expression<Func<ParticipationResult, bool>>? predicate = null,
        Func<IQueryable<ParticipationResult>, IOrderedQueryable<ParticipationResult>>? orderBy = null,
        Func<IQueryable<ParticipationResult>, IIncludableQueryable<ParticipationResult, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ParticipationResult> AddAsync(ParticipationResult participationResult);
    Task<ParticipationResult> UpdateAsync(ParticipationResult participationResult);
    Task<ParticipationResult> DeleteAsync(ParticipationResult participationResult, bool permanent = false);

    public Task<ParticipationResult> UpdateOrCreateByParticipationResult(Guid surveyId);
}
