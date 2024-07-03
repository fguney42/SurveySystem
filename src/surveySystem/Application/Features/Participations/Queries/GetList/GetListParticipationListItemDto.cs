using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Participations.Queries.GetList;

public class GetListParticipationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Answer { get; set; }
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }
}