using Application.Features.Surveys.Constants;
using Application.Features.Surveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Surveys.Constants.SurveysOperationClaims;
using Application.Features.OperationClaims.Constants;
using Application.Features.Members.Queries;

namespace Application.Features.Surveys.Members.GetById;

public class GetMemberFromAuth : IRequest<GetMemberFromAuthResponse>, ISecuredRequest
{
    public int UserId { get; set; }

    public string[] Roles => [Admin, Read, OperationClaimsOperationClaims.MemberRole];

    public class GetMemberFromAuthHandler : IRequestHandler<GetMemberFromAuth, GetMemberFromAuthResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;
        private readonly SurveyBusinessRules _surveyBusinessRules;

        public GetMemberFromAuthHandler(IMapper mapper, IMemberRepository memberRepository)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
        }

        public async Task<GetMemberFromAuthResponse> Handle(GetMemberFromAuth request, CancellationToken cancellationToken)
        {
            Member? survey = await _memberRepository.GetAsync(predicate: m => m.UserId == request.UserId, cancellationToken: cancellationToken);

            GetMemberFromAuthResponse response = _mapper.Map<GetMemberFromAuthResponse>(survey);
            return response;
        }
    }
}