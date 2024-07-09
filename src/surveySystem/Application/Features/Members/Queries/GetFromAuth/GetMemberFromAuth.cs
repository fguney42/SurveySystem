//using Application.Features.Members.Queries.GetById;
//using Application.Features.Members.Rules;
//using Application.Features.Users.Commands.UpdateFromAuth;
//using Application.Features.Users.Rules;
//using Application.Services.AuthService;
//using Application.Services.Repositories;
//using AutoMapper;
//using Domain.Entities;
//using MediatR;
//using NArchitecture.Core.Security.Entities;
//using NArchitecture.Core.Security.Hashing;

//namespace Application.Features.Members.Queries.GetFromAuth;

//public class GetMemberFromAuth : IRequest<GetByIdMemberResponse>
//{
//    public int UserId { get; set; }

//    public class GetMemberFromAuthCommandHandler : MediatR.IRequestHandler<GetMemberFromAuth, GetMemberFromAuthResponse>
//    {
//        private readonly IMemberRepository _memberRepository;
//        private readonly IMapper _mapper;
//        private readonly MemberBusinessRules _memberBusinessRules;
//        private readonly IAuthService _authService;

//        public GetMemberFromAuthCommandHandler(
//            IMemberRepository memberRepository,
//            IMapper mapper,
//            IAuthService authService,
//            MemberBusinessRules memberBusinessRules)
//        {
//            _memberRepository = memberRepository;
//            _mapper = mapper;
//            _authService = authService;
//            _memberBusinessRules = memberBusinessRules;
//        }

//        public async Task<GetMemberFromAuthResponse> Handle(GetMemberFromAuth request, CancellationToken cancellationToken)
//        {
//            Member? member = await _memberRepository.GetAsync(predicate: m => m.UserId == request.UserId, cancellationToken: cancellationToken);
//            await _memberBusinessRules.MemberShouldExistWhenSelected(member);

//            GetMemberFromAuthResponse response = _mapper.Map<GetMemberFromAuthResponse>(member);
//            return response;
//        }
//    }
//}

