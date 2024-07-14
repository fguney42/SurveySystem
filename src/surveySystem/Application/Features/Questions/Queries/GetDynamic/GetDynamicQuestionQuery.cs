using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Queries.GetDynamic;
public class GetDynamicQuestionQuery : IRequest<GetListResponse<GetDynamicQuestionListItemDto>>
{
    public DynamicQuery DynamicQuery { get; set; }

    public PageRequest PageRequest { get; set; }
    public class GetDynamicQuestionQueryHandler : MediatR.IRequestHandler<GetDynamicQuestionQuery, GetListResponse<GetDynamicQuestionListItemDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetDynamicQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicQuestionListItemDto>> Handle(GetDynamicQuestionQuery request, CancellationToken cancellationToken)
        {
           IPaginate<Question> questions = 
                await _questionRepository.GetListByDynamicAsync(dynamic : request.DynamicQuery, index : request.PageRequest.PageIndex, size : request.PageRequest.PageSize, cancellationToken : cancellationToken, include : d => d.Include(d => d.Survey)!);
                
            GetListResponse<GetDynamicQuestionListItemDto> response = _mapper.Map<GetListResponse<GetDynamicQuestionListItemDto>>(questions);

            return response;
        }
    }
}
