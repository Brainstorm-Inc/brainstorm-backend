using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Commands;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using Brainstorm.Entities.Project;
using Brainstorm.Entities.Topic;
using MediatR;

namespace Brainstorm.Business.Organization.Handlers;

public class CreateProjectInOrgCommandHandler : IRequestHandler<CreateProjectInOrgCommand, CreateProjectInOrgResponse>
{
    private BrainstormContext _ctx;

    public CreateProjectInOrgCommandHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<CreateProjectInOrgResponse> Handle(CreateProjectInOrgCommand request,
        CancellationToken cancellationToken)
    {
        var org = _ctx.Organizations.FirstOrDefault(o => o.Id == request.OrgId) ??
                  throw new Exception("Organization doesn't exist.");

        var proj = new Project
        {
            Name = request.Name,
            Org = org,
            Topics = new List<Topic>()
        };

        org.Projects.Add(proj);
        var res = _ctx.Projects.Add(proj).Entity;
        _ctx.SaveChanges();

        return Task.FromResult(
            new CreateProjectInOrgResponse
            {
                Id = res.Id,
                Name = res.Name,
                OrgId = res.Org.Id,
                Topics = proj.Topics
            });
    }
}