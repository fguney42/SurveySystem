using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Surveys.Queries.GetList;

public class GetListSurveyListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}