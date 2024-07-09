using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ParticipationResults.Queries.GetList;

public class GetListParticipationResultListItemDto : IDto
{
    public Guid Id { get; set; }
    public int Result { get; set; }
    public Guid SurveyId { get; set; }
    public double PercentYes { get; set; }
    public double PercentNo { get; set; }
}