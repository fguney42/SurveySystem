using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Queries.GetDynamic;
public class GetDynamicQuestionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; }
    public Guid SurveyId { get; set; }
    public string SurveyTitle { get; set; }
}
