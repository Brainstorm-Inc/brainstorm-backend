using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Commands;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using Brainstorm.Entities.User;
using MediatR;

namespace Brainstorm.Business.Organization.Handlers;

public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, DeleteOrganizationResponse>
{
    private BrainstormContext _ctx;

    public DeleteOrganizationCommandHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<DeleteOrganizationResponse> Handle(DeleteOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        var org = _ctx.Organizations.FirstOrDefault(o => o.Id == request.OrgId);
        if (org is null)
        {
            throw new Exception("Organization doesn't exist");
        }

        _ctx.Organizations.Remove(org);
        RemoveUsersFromOrg(org.Users);
        _ctx.SaveChanges();

        return Task.FromResult(new DeleteOrganizationResponse());
    }

    private static void RemoveUsersFromOrg(IEnumerable<User> users)
    {
        Parallel.ForEach(users, (u) => u.Org = null);
    }
}