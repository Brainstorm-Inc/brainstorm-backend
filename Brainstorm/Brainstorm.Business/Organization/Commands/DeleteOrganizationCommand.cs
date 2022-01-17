using System;
using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Commands;

public class DeleteOrganizationCommand:IRequest<DeleteOrganizationResponse>
{
    public Guid OrgId { get; init; }
}