using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Organization.Handlers;

public class DeleteOrganizationQueryHandler : IRequestHandler<DeleteOrganizationQuery, DeleteOrganizationResponse>
{
    private readonly BrainstormContext _ctx;

    public DeleteOrganizationQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<DeleteOrganizationResponse> Handle(DeleteOrganizationQuery request, CancellationToken cancellationToken)
    {
        var orgId = Guid.Parse(request.OrgId);
        var org = _ctx.Organizations.FirstOrDefault(o => o.Id == orgId);

        if (org is null)
        {
            throw new Exception("Organization doesn't exist.");
        }
        
        var creatorId = Guid.Parse(request.CreatorId);
        var user = _ctx.Users.FirstOrDefault(u => u.Id == creatorId);

        if (user is null)
        {
            throw new Exception("User doesn't exists");
        }
        
        org.Users.Remove(user);
        _ctx.SaveChanges();

        return Task.FromResult(new DeleteOrganizationResponse());
    }
}