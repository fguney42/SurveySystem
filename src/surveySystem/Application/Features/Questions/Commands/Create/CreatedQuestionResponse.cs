using NArchitecture.Core.Application.Responses;

namespace Application.Features.Questions.Commands.Create;

public class CreatedQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; }
    public Guid SurveyId { get; set; }
}