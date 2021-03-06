using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Users.Queries;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Users.Handlers;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetails>
{
    private readonly BrainstormContext _ctx;

    public GetUserQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<UserDetails> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        if (!_ctx.Users.Any())
        {
            throw new Exception("No user found.");
        }

        var code = _ctx.Users
            .FirstOrDefault(u => u.Id == request.UserId)
            .ToUserDetails();

        return Task.FromResult(code);
    }
}