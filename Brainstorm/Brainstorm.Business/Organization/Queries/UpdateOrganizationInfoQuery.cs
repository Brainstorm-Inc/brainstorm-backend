using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Queries;

public class UpdateOrganizationInfoQuery : IRequest<UpdateOrganizationInfoResponse>
{
    public string OrgId { get; init; }
    public string UserId { get; init; }

    public string Name { get; init; }

    public string Logo { get; init; }
}