using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Commands;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Organization.Handlers;

public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, UpdateOrganizationResponse>
{
    private BrainstormContext _ctx;

    public UpdateOrganizationCommandHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<UpdateOrganizationResponse> Handle(UpdateOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        var org = _ctx.Organizations.FirstOrDefault(o => o.Id == request.OrgId) ??
                  throw new Exception("Organization doesn't exist.");

        if (request.Name != "")
        {
            org.Name = request.Name;
        }

        if (request.Logo != "")
        {
            org.LogoLink = request.Logo;
        }

        _ctx.Organizations.Update(org);

        _ctx.SaveChanges();

        var res = new UpdateOrganizationResponse
        {
            Id = org.Id,
            Name = org.Name,
            Logo = org.LogoLink
        };

        return Task.FromResult(res);
    }
}