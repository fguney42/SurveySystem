using FluentValidation;

namespace Application.Features.ParticipationResults.Commands.Create;

public class CreateParticipationResultCommandValidator : AbstractValidator<CreateParticipationResultCommand>
{
    public CreateParticipationResultCommandValidator()
    {
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}