using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Question : Entity<Guid>
{
    public string QuestionText { get; set; }
    public virtual Survey? Survey { get; set; }
    public Guid SurveyId { get; set; }
    public ParticipationResult? ParticipationResult { get; set; }
    public Question()
    {
    }
    public Question(string questionText)
    {
        QuestionText = questionText;
    }


}
