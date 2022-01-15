using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.AppVersions.Handlers;

public class RemoveUserFromOrgQueryHandler : IRequestHandler<RemoveUserFromOrgQuery, RemoveUserFromOrgResponse>
{
    private readonly BrainstormContext _ctx;

    public RemoveUserFromOrgQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<RemoveUserFromOrgResponse> Handle(RemoveUserFromOrgQuery request, CancellationToken cancellationToken)
    {
        var orgId = Guid.Parse(request.OrgId);
        var org = _ctx.Organizations.FirstOrDefault(o => o.Id == orgId);

        if (org is null)
        {
            throw new Exception("Organization doesn't exist.");
        }

        var userId = Guid.Parse(request.UserId);
        var user = _ctx.Users.FirstOrDefault(u => u.Id == userId);

        if (user is null)
        {
            throw new Exception("User doesn't exist.");
        }

        if (org.Users.FirstOrDefault(u => u.Id == userId) is null)
        {
            throw new Exception("User is not in the organization.");
        }

        org.Users.Remove(user);
        _ctx.SaveChanges();

        return Task.FromResult(new RemoveUserFromOrgResponse());
    }
}