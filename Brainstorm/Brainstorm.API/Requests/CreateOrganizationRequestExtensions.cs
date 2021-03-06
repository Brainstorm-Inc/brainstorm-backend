using System;
using System.Collections.Generic;
using Brainstorm.Business.Organization.Commands;
using Brainstorm.Entities.User;

namespace Brainstorm.API.Requests
{
    public static class CreateOrganizationRequestExtensions
    {
        public static CreateOrganizationCommand ToCommand(this CreateOrganizationRequest request, string creatorId)
        {
            return new CreateOrganizationCommand
            {
                Name = request.Name,
                LogoLink = request.Logo,
                CreatorId =  new Guid(creatorId)
            };
        }
    }
}