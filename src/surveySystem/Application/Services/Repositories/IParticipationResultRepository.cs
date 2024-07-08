using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IParticipationResultRepository : IAsyncRepository<ParticipationResult, Guid>, IRepository<ParticipationResult, Guid>
{
    public Task<int> IncrementParticipationResult(Guid participationResultId);
}