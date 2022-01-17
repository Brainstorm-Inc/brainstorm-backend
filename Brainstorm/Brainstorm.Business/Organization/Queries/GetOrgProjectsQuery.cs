using System;
using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Queries;

public class GetOrgProjectsQuery : IRequest<GetOrgProjectsResponse>
{
    public Guid OrgId { get; init; }
}