using NArchitecture.Core.Application.Responses;

namespace Application.Features.Participations.Commands.Update;

public class UpdatedParticipationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Answer { get; set; }
    public Guid MemberId { get; set; }
    public Guid SurveyId { get; set; }
}