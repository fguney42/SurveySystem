using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Questions.Queries.GetList;

public class GetListQuestionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; }
    public Guid SurveyId { get; set; }
}