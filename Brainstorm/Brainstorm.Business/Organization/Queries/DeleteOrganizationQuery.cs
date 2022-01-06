using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Queries;

public class DeleteOrganizationQuery : IRequest<DeleteOrganizationResponse>
{
    public string CreatorId { get; init; }
    public string OrgId { get; init; }
}