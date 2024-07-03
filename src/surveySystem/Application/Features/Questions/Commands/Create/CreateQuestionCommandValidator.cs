using FluentValidation;

namespace Application.Features.Questions.Commands.Create;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(c => c.QuestionText).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}