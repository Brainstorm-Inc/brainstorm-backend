using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Queries;

public class AddUserToOrgQuery : IRequest<AddUserToOrgResponse>
{
    public string OrgId { get; init; }
    public string UserId { get; init; }
}