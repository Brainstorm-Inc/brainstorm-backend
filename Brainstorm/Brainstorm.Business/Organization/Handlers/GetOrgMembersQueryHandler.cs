using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Business.Users;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Brainstorm.Business.Organization.Handlers;

public class GetOrgMembersHandler : IRequestHandler<GetOrgMembersQuery, OrgMembers>
{
    private readonly BrainstormContext _ctx;

    public GetOrgMembersHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<OrgMembers> Handle(GetOrgMembersQuery request, CancellationToken cancellationToken)
    {
        var orgId = Guid.Parse(request.OrgId);
        var org = _ctx.Organizations
            .Include(org => org.Users)
            .FirstOrDefault(o => o.Id == orgId);

        if (org is null)
        {
            throw new Exception("Organization doesn't exist.");
        }

        var usersDetails = new List<UserDetails>();
        foreach (var user in org.Users)
        {
            usersDetails.Add(user.ToUserDetails());
        }
        
        var res = new OrgMembers {usersDetails = usersDetails.ToList()};

        return Task.FromResult(res);
    }
}