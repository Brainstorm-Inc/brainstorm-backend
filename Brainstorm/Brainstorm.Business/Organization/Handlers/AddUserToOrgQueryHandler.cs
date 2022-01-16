using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Brainstorm.Business.Organization.Handlers;

public class AddUserToOrgQueryHandler : IRequestHandler<AddUserToOrgQuery, AddUserToOrgResponse>
{
    private readonly BrainstormContext _ctx;

    public AddUserToOrgQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<AddUserToOrgResponse> Handle(AddUserToOrgQuery request, CancellationToken cancellationToken)
    {
        var orgId = Guid.Parse(request.OrgId);
        var org = _ctx.Organizations
            .Include(org => org.Users)
            .FirstOrDefault(o => o.Id == orgId);

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

        if (org.Users.FirstOrDefault(u => u.Id == userId) is not null)
        {
            throw new Exception("User is already a member in the organization.");
        }

        org.Users.Add(user);
        _ctx.SaveChanges();

        return Task.FromResult(new AddUserToOrgResponse());
    }
}