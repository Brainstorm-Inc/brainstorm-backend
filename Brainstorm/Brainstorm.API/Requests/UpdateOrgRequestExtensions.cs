using System;
using Brainstorm.Business.Organization.Commands;

namespace Brainstorm.API.Requests;

public static class UpdateOrgRequestExtensions
{
    public static UpdateOrganizationCommand ToCommand(this UpdateOrgRequest request, Guid orgId)
    {
        return new UpdateOrganizationCommand
        {
            OrgId = orgId,
            Name = request.Name,
            Logo = request.Logo
        };
    }
}