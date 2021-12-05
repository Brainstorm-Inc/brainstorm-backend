using System.Collections.Generic;
using Brainstorm.Entities.User;

namespace Brainstorm.Business.Organization.Commands
{
    public static class CreateOrganizationCommandExtensions
    {
        public static Entities.Organization.Organization ToOrganization(this CreateOrganizationCommand command)
        {
            return new Entities.Organization.Organization
            {
                Name = command.Name,
                Users = new List<User>(),
                LogoLink = command.LogoLink
                // LogoLink = $"https://robohash.org/{command.Name}.png"
            };
        }
    }
}