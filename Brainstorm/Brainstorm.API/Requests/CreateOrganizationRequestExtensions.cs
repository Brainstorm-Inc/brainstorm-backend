using System.Collections.Generic;
using Brainstorm.Business.Organization.Commands;
using Brainstorm.Entities.User;

namespace Brainstorm.API.Requests
{
    public static class CreateOrganizationRequestExtensions
    {
        public static CreateOrganizationCommand ToCommand(this CreateOrganizationRequest request)
        {
            return new CreateOrganizationCommand
            {
                Name = request.Name,
                Users = new List<User>(),
                LogoLink = request.LogoLink,
                // CreatorId =  // TODO get from path parameter
            };
        }
    }
}