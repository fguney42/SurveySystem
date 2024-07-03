using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Survey : Entity<Guid>
    {
        public string Title { get; set; }
        public virtual IList<Question>? Questions { get; set; }
        public virtual IList<Participation>? Participations { get; set; }
        public Survey()
        {
        }
        public Survey(string title)
        {
            Title = title;
        }
    }
}
