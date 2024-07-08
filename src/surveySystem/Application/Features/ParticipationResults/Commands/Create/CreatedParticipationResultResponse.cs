using NArchitecture.Core.Application.Responses;

namespace Application.Features.ParticipationResults.Commands.Create;

public class CreatedParticipationResultResponse : IResponse
{
    public Guid Id { get; set; }
    public int Result { get; set; }
    public Guid SurveyId { get; set; }
}