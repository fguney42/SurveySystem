using Application.Features.Members.Constants;
using Application.Features.Members.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Members.Constants.MembersOperationClaims;
using Microsoft.EntityFrameworkCore;
using Application.Features.OperationClaims.Constants;
using NArchitecture.Core.Application.Pipelines.Caching;

namespace Application.Features.Members.Queries.GetById;

public class GetByIdMemberQuery : IRequest<GetByIdMemberResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read, OperationClaimsOperationClaims.MemberRole];


    public class GetByIdMemberQueryHandler : IRequestHandler<GetByIdMemberQuery, GetByIdMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;
        private readonly MemberBusinessRules _memberBusinessRules;

        public GetByIdMemberQueryHandler(IMapper mapper, IMemberRepository memberRepository, MemberBusinessRules memberBusinessRules)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
            _memberBusinessRules = memberBusinessRules;
        }

        public async Task<GetByIdMemberResponse> Handle(GetByIdMemberQuery request, CancellationToken cancellationToken)
        {
            Member? member = await _memberRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken, include : m => m.Include(m=> m.User)!);
            await _memberBusinessRules.MemberShouldExistWhenSelected(member);

            GetByIdMemberResponse response = _mapper.Map<GetByIdMemberResponse>(member);
            return response;
        }
    }
}