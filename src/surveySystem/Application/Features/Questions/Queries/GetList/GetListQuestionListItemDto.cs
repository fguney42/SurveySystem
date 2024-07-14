using MailKit;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Questions.Queries.GetList;

public class GetListQuestionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; }
    public Guid SurveyId { get; set; }
    public string SurveyTitle {  get; set; }
    public Guid ParticipationResultId { get; set; }
    public int ParticipationResultResult { get; set; }
    public double? ParticipationResultPercentYes { get; set; }
    public double? ParticipationResultPercentNo { get; set; } 

    public int ParticipationResultTotalNoAnswer { get; set; }
    public int ParticipationResultTotalYesAnswer { get; set; }

}