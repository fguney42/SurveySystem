using NArchitecture.Core.Application.Responses;

namespace Application.Features.ParticipationResults.Queries.GetById;

public class GetByIdParticipationResultResponse : IResponse
{
    public Guid Id { get; set; }
    public int Result { get; set; }
    public Guid SurveyId { get; set; }
    public double? PercentYes { get; set; }
    public double? PercentNo { get; set; } 
    public int TotalNoAnswer { get; set; }
    public int TotalYesAnswer { get; set; }
    public string QuestionQuestionText{ get; set; }
}