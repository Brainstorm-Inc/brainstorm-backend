using System;
using Brainstorm.Business.Organization.Queries;

namespace Brainstorm.API.Requests
{
    public static class GetOrganizationInfoRequestExtensions
    {
        public static GetOrganizationInfoQuery ToQuery(this GetOrganizationInfoRequest request, string orgId)
        {
            return new GetOrganizationInfoQuery
            {
                Id = new Guid(orgId)
            };
        }
    }
}