using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Security.Entities;

namespace Domain.Entities;
public class Participation : Entity<Guid>
{
    public string Answer { get; set; }
    public virtual User<Guid, int>? User { get; set; }
    public virtual Survey? Survey { get; set; }
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }
   
    public Participation()
    {
    }
    public Participation(string answer)
    {
        Answer = answer;
    }
}
