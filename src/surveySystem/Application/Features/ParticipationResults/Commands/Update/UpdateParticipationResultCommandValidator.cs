using FluentValidation;

namespace Application.Features.ParticipationResults.Commands.Update;

public class UpdateParticipationResultCommandValidator : AbstractValidator<UpdateParticipationResultCommand>
{
    public UpdateParticipationResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Result).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}