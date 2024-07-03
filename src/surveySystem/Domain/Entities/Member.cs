using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Member : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int UserId { get; set; }
    public virtual User<int, int>? User { get; set; }
    public Member()
    {

    }
    public Member(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
