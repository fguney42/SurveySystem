using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ParticipationResults.Queries.GetList;

public class GetListParticipationResultListItemDto : IDto
{
    public Guid Id { get; set; }
    public int Result { get; set; }
    public Guid SurveyId { get; set; }
    public double PercentYes { get; set; }
    public double PercentNo { get; set; }
    public Guid QuestionId { get; set; }
    public int TotalYesAnswer{ get; set; }
    public int TotalNoAnswer{ get; set; }
    public string SurveyTitle { get; set; }
    public string QuestionQuestionText{ get; set; }
}