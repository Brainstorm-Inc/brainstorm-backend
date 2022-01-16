using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization;
using Brainstorm.Business.Users.Queries;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Brainstorm.Business.Users.Handlers;

public class GetOrgsForUserQueryHandler : IRequestHandler<GetUserOrgsQuery, OrgsDetails>
{
    private readonly BrainstormContext _ctx;

    public GetOrgsForUserQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<OrgsDetails> Handle(GetUserOrgsQuery request, CancellationToken cancellationToken)
    {
        if (!_ctx.Users.Any())
        {
            throw new Exception("No user found.");
        }

        var currentUser = _ctx.Users
            .Include(user => user.Org)
            .FirstOrDefault(user => user.Id == request.UserId);
        
        if (currentUser.Org is null)
        {
            return Task.FromResult(new OrgsDetails());
        }
        
        var org = currentUser.Org.ToOrgsDetails();

        return Task.FromResult(org);
    }
}