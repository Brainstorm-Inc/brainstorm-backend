using System;
using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Commands;

public class CreateProjectInOrgCommand: IRequest<CreateProjectInOrgResponse>
{
    public string Name { get; set; }
    public Guid OrgId { get; set; }
}