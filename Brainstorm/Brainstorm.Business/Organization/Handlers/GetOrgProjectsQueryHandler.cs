using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Organization.Handlers;

public class GetOrgProjectsQueryHandler : IRequestHandler<GetOrgProjectsQuery, GetOrgProjectsResponse>
{
    private BrainstormContext _ctx;

    public GetOrgProjectsQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<GetOrgProjectsResponse> Handle(GetOrgProjectsQuery request, CancellationToken cancellationToken)
    {
        var org = _ctx.Organizations.FirstOrDefault(o => o.Id == request.OrgId) ??
                  throw new Exception("Organization doesn't exist.");

        var projectIds = org.Projects
            .Select(p => p.Id.ToString())
            .ToList();

        return Task.FromResult(new GetOrgProjectsResponse
        {
            Projects = projectIds
        });
    }
}