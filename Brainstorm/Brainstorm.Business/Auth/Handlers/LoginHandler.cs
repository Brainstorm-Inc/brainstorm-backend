using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Auth.Queries;
using Brainstorm.Business.Auth.Responses;
using Brainstorm.Business.Utils;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Auth.Handlers;

public class LoginHandler : IRequestHandler<LoginQuery, LoginResponse>
{
    private readonly BrainstormContext _ctx;

    public LoginHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = _ctx.Users
            .FirstOrDefault(u => request.Email == u.Email);

        if (user is null)
        {
            throw new Exception($"User with email address {request.Email} does not exist.");
        }

        var hash = Utils.GenerateSaltedHash(request.Password, user.Salt);

        if (hash != user.Password) {
          throw new Exception("Wrong credentials.");
        }

        var token = AuthUtils.GenerateToken(request.Email);

        var res = new LoginResponse
        {
            Id = user.Id,
            Email = request.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            ProfilePicture = user.ProfilePicture,
            Token = token
        };
        return Task.FromResult(res);
    }
}
