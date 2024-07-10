using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ParticipationResult : Entity<Guid>
{
    public int Result { get; set; } = 0;
    public double? PercentYes { get; set; } = 0;
    public double? PercentNo { get; set; } = 0;

    public int TotalNoAnswer { get; set; } = 0;
    public int TotalYesAnswer { get; set; } = 0;
    public Guid SurveyId { get; set; }
}
