using FluentValidation;

namespace Application.Features.Questions.Commands.Update;

public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.QuestionText).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}