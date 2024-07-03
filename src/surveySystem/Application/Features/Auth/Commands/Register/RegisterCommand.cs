using Application.Features.Auth.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Features.Users.Constants;
using Application.Services.AuthService;
using Application.Services.OperationClaims;
using Application.Services.Repositories;
using Application.Services.UserOperationClaims;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Entities;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;
using Org.BouncyCastle.Security;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, IOperationClaimService operationClaimService, AuthBusinessRules authBusinessRules, IUserOperationClaimService userOperationClaimService)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User<int, int> newUser =
                new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
            User<int, int> createdUser = await _userRepository.AddAsync(newUser);

            UserOperationClaim<int,int> userOperationClaim = new ()
            {
                OperationClaimId =
                await _operationClaimService.GetOperationClaimIdByName(OperationClaimsOperationClaims.MemberRole)
            };

            await _userOperationClaimService.AddAsync(userOperationClaim);

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
