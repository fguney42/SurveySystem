using NArchitecture.Core.Application.Responses;

namespace Application.Features.Participations.Commands.Create;

public class CreatedParticipationResponse : IResponse
{
    public string Answer { get; set; }
    public Guid MemberId { get; set; }
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }

}