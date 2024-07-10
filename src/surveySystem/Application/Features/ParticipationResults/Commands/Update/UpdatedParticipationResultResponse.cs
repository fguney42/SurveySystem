using NArchitecture.Core.Application.Responses;

namespace Application.Features.ParticipationResults.Commands.Update;

public class UpdatedParticipationResultResponse : IResponse
{
    public Guid Id { get; set; }
    public int Result { get; set; }
    public Guid SurveyId { get; set; }
}