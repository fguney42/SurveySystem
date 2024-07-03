using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.DTOs;

public class MemberForRegisterDto : IDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserForRegisterDto UserForRegisterDto { get; set; }
}
