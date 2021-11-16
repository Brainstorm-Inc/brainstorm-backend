using Brainstorm.Business.Auth.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainstorm.Business.Auth.Commands
{
    public class SignupCommand: IRequest<SignupResponse>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }


    }
}
