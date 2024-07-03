using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities;
public class Participation : Entity<Guid>
{
    public string Answer { get; set; }
    public virtual Member? Member { get; set; }
    public virtual Survey? Survey { get; set; }
    public Guid MemberId { get; set; }
    public Guid SurveyId { get; set; }
    public Participation()
    {
    }
    public Participation(string answer)
    {
        Answer = answer;
    }

}
