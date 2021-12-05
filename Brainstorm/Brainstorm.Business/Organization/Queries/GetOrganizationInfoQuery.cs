using System;
using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Queries
{
    public class GetOrganizationInfoQuery : IRequest<GetOrganizationInfoResponse>
    {
        public Guid Id { get; init; }
    }
}