using FluentValidation;

namespace Application.Features.Participations.Commands.Create;

public class CreateParticipationCommandValidator : AbstractValidator<CreateParticipationCommand>
{
    public CreateParticipationCommandValidator()
    {
        RuleFor(c => c.Answer).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}