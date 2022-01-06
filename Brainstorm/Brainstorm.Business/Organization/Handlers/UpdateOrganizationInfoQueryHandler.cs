using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Organization.Handlers;

public class UpdateOrganizationInfoQueryHandler : IRequestHandler<UpdateOrganizationInfoQuery, UpdateOrganizationInfoResponse>
{
    private readonly BrainstormContext _ctx;

    public UpdateOrganizationInfoQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<UpdateOrganizationInfoResponse> Handle(UpdateOrganizationInfoQuery request,
        CancellationToken cancellationToken)
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
            throw new Exception("User doesn't exists");
        }

        bool changed = false;
        if (request.Name != null)
        {
            org.Name = request.Name;
            changed = true;
        }

        if (request.Logo != null)
        {
            org.LogoLink = request.Logo;
            changed = true;
        }

        if (changed)
        {
            _ctx.Update(org);
            _ctx.SaveChanges();
            var res = new UpdateOrganizationInfoResponse { name = request.Name, logo = request.Logo };
            return Task.FromResult(res);
        }

        return Task.FromResult(new UpdateOrganizationInfoResponse());
    }
}