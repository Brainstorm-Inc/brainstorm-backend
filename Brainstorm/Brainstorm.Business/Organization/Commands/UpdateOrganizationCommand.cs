using System;
using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Commands;

public class UpdateOrganizationCommand: IRequest<UpdateOrganizationResponse>
{
    public Guid OrgId { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
}
