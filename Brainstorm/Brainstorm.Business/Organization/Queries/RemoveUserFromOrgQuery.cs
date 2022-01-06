using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Queries;

public class RemoveUserFromOrgQuery : IRequest<RemoveUserFromOrgResponse>
{
    public string OrgId { get; init; }
    public string UserId { get; init; }
}