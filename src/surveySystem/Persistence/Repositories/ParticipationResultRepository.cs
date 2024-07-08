using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ParticipationResultRepository : EfRepositoryBase<ParticipationResult, Guid, BaseDbContext>, IParticipationResultRepository
{
    public ParticipationResultRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<int> IncrementParticipationResult(Guid participationResultId)
    {
        ParticipationResult? participationResult = await GetAsync(pr => pr.Id.Equals(participationResultId));

        return (participationResult!.Result + 1);
    }
}