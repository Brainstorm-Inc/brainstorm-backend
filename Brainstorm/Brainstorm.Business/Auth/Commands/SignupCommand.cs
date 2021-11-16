using Brainstorm.Business.Auth.Responses;
using MediatR;

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
