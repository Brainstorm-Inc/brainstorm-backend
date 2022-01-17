using Brainstorm.Business.Users.Responses;

namespace Brainstorm.Business.Organization;

public static class OrganizationExtensions
{
    public static OrgsDetails ToOrgsDetails(this Entities.Organization.Organization organization)
    {
        return new OrgsDetails()
        {
            Id = organization.Id.ToString(),
            Name = organization.Name,
            Logo = organization.LogoLink,
        };
    }
}