using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IParticipationRepository : IAsyncRepository<Participation, Guid>, IRepository<Participation, Guid>
{
}