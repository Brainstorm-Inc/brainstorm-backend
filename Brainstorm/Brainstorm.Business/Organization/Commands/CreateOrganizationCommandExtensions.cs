using System.Collections.Generic;
using Brainstorm.Entities.User;
using Microsoft.IdentityModel.Tokens;

namespace Brainstorm.Business.Organization.Commands
{
    public static class CreateOrganizationCommandExtensions
    {
        public static Entities.Organization.Organization ToOrganization(this CreateOrganizationCommand command)
        {
            string logo = command.LogoLink;
            if (logo.IsNullOrEmpty())
            {
                logo = $"https://robohash.org/{command.Name}.png";
            }
            
            Entities.Organization.Organization org = new Entities.Organization.Organization
            {
                Name = command.Name,
                Users = new List<User>(),
                // LogoLink = command.LogoLink
                LogoLink = logo
            };
            
            // org.Users.Add(command.CreatorId); // TODO get creator from ID and add it to Users

            return org;
        }
    }
}