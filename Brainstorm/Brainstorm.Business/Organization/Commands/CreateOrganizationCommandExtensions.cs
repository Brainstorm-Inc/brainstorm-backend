using System.Collections.Generic;

using Brainstorm.Entities.Organization;
using Brainstorm.Entities.User;
using Microsoft.IdentityModel.Tokens;

namespace Brainstorm.Business.Organization.Commands
{
    public static class CreateOrganizationCommandExtensions
    {
        public static Entities.Organization.Organization ToOrganization(this CreateOrganizationCommand command)
        {
            var org = new Entities.Organization.Organization
            {
                Name = command.Name,
                Users = new List<User>(),
                // LogoLink = command.LogoLink
                LogoLink = command.LogoLink.IsNullOrEmpty() ? $"https://robohash.org/{command.Name}.png" : command.LogoLink
            };
            
            // org.Users.Add(command.CreatorId); // TODO get creator from ID and add it to Users

            return org;
        }
    }
}
