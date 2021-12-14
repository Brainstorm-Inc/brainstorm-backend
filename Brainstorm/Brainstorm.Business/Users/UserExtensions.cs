using Brainstorm.Business.AppVersions.Responses;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities.User;

namespace Brainstorm.Business.Users;

public static class UserExtensions
{
    public static UserDetails ToUserCode(this User user)
    {
        return new UserDetails
        {
            Id = user.Id.ToString(),
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            ProfilePicture = user.ProfilePicture
        };
    }
}