using Application.Features.Questions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Questions.Constants.QuestionsOperationClaims;
using Application.Features.OperationClaims.Constants;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Questions.Queries.GetList;

public class GetListQuestionQuery : IRequest<GetListResponse<GetListQuestionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read, OperationClaimsOperationClaims.MemberRole];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListQuestions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetQuestions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListQuestionQueryHandler : IRequestHandler<GetListQuestionQuery, GetListResponse<GetListQuestionListItemDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetListQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListQuestionListItemDto>> Handle(GetListQuestionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Question> questions = await _questionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken,
                include : q => q.Include(q => q.Survey).Include(q=>q.ParticipationResult)!
            );

            GetListResponse<GetListQuestionListItemDto> response = _mapper.Map<GetListResponse<GetListQuestionListItemDto>>(questions);
            return response;
        }
    }
}