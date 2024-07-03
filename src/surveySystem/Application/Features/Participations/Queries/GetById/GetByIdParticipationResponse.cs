using NArchitecture.Core.Application.Responses;

namespace Application.Features.Participations.Queries.GetById;

public class GetByIdParticipationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Answer { get; set; }
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }
}