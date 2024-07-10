using NArchitecture.Core.Application.Responses;

namespace Application.Features.ParticipationResults.Commands.Create;

public class CreatedParticipationResultResponse : IResponse
{
    public int Result { get; set; }
    public double PercentNo { get; set; }    
    public double PercentYes { get; set; }
    public Guid Id { get; set; }
    public Guid SurveyId { get; set; }
}