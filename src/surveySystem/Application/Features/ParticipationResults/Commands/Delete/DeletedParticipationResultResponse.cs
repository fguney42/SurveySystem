using NArchitecture.Core.Application.Responses;

namespace Application.Features.ParticipationResults.Commands.Delete;

public class DeletedParticipationResultResponse : IResponse
{
    public Guid Id { get; set; }
}