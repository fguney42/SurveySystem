using FluentValidation;

namespace Application.Features.ParticipationResults.Commands.Delete;

public class DeleteParticipationResultCommandValidator : AbstractValidator<DeleteParticipationResultCommand>
{
    public DeleteParticipationResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}