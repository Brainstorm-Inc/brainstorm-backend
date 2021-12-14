using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;

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
        var org = _ctx.Organizations.FirstOrDefault(o => o.Id == orgId);

        if (org is null)
        {
            throw new Exception("Organization doesn't exist.");
        }

        var res = new OrgMembers {users = org.Users.ToList()};

        return Task.FromResult(res);
    }
}