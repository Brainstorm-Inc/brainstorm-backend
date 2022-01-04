using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.AppVersions.Handlers;

public class CheckUserInOrgQueryHandler : IRequestHandler<CheckUserInOrgQuery, CheckUserInOrgResponse>
{
    private readonly BrainstormContext _ctx;

    public CheckUserInOrgQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<CheckUserInOrgResponse> Handle(CheckUserInOrgQuery request, CancellationToken cancellationToken)
    {
        var orgId = Guid.Parse(request.OrgId);
        var org = _ctx.Organizations.FirstOrDefault(o => o.Id == orgId);

        if (org is null)
        {
            throw new Exception("Organization doesn't exist.");
        }

        var userId = Guid.Parse(request.UserId);
        var user = org.Users.FirstOrDefault(u => u.Id == userId);

        if (user is null)
        {
            throw new Exception("User is not a member in the organization.");
        }

        return Task.FromResult(new CheckUserInOrgResponse());
    }
}