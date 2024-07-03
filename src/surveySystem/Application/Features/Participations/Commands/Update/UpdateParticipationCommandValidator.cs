using FluentValidation;

namespace Application.Features.Participations.Commands.Update;

public class UpdateParticipationCommandValidator : AbstractValidator<UpdateParticipationCommand>
{
    public UpdateParticipationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Answer).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}