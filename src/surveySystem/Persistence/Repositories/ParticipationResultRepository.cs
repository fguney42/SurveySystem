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
    public async Task<double> CalculatePercentYes(int totalNoAnswer, int totalYesAnswer)
    {
        if (totalYesAnswer > 0)
            return ((double)totalYesAnswer / (double)(totalNoAnswer + totalYesAnswer)) * 100; 
        return 0;
    }
    public async Task<double> CalculatePercentNo(int totalNoAnswer, int totalYesAnswer)
    {
        if (totalNoAnswer > 0)
            return ((double)totalNoAnswer / (double)(totalNoAnswer + totalYesAnswer)) * 100;
        return 0;

    }
}