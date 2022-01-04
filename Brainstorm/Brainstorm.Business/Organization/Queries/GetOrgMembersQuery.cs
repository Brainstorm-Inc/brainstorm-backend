using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Queries;

public class GetOrgMembersQuery:IRequest<OrgMembers>
{
    public string OrgId { get; init; }
}