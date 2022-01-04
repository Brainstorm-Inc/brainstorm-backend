using Brainstorm.Business.Auth.Responses;
using MediatR;

namespace Brainstorm.Business.Auth.Queries;

public class LoginQuery : IRequest<LoginResponse>
{
    public string Email { get; init; }
    public string Password { get; init; }
}