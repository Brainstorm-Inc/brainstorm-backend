using System;
using Brainstorm.Business.Organization.Commands;

namespace Brainstorm.API.Requests;

public static class CreateProjectInOrgRequestExtensions
{
   public static CreateProjectInOrgCommand ToCommand(this CreateProjectInOrgRequest request, Guid orgId)
   {
      return new CreateProjectInOrgCommand
      {
         Name = request.Name,
         OrgId = orgId
      };
   }
}