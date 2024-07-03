using Application.Features.Auth.Commands.DTOs;
using Application.Features.Auth.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Features.Users.Constants;
using Application.Services.AuthService;
using Application.Services.Members;
using Application.Services.OperationClaims;
using Application.Services.Repositories;
using Application.Services.UserOperationClaims;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Entities;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;
using Org.BouncyCastle.Security;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public MemberForRegisterDto MemberForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        MemberForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(MemberForRegisterDto memberForRegisterDto, string ipAddress)
    {
        MemberForRegisterDto = memberForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMemberService _memberService;

        public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, IOperationClaimService operationClaimService, AuthBusinessRules authBusinessRules, IUserOperationClaimService userOperationClaimService, IMemberService memberService)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
            _memberService = memberService;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.MemberForRegisterDto.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.MemberForRegisterDto.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User<int, int> newUser =
                new()
                {
                    Email = request.MemberForRegisterDto.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
            User<int, int> createdUser = await _userRepository.AddAsync(newUser);

            Member member = new()
            {
                FirstName = request.MemberForRegisterDto.FirstName,
                LastName = request.MemberForRegisterDto.LastName,
                UserId = createdUser.Id,
            };

            UserOperationClaim<int,int> userOperationClaim = new ()
            {
                UserId = createdUser.Id,
                OperationClaimId =
                await _operationClaimService.GetOperationClaimIdByName(OperationClaimsOperationClaims.MemberRole)
            };

            await _userOperationClaimService.AddAsync(userOperationClaim);
            await _memberService.AddAsync(member);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            NArchitecture.Core.Security.Entities.RefreshToken<int, int> createdRefreshToken = await _authService.CreateRefreshToken(
                createdUser,
                request.IpAddress
            );
            NArchitecture.Core.Security.Entities.RefreshToken<int, int> addedRefreshToken = await _authService.AddRefreshToken(
                createdRefreshToken
            );

            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}
