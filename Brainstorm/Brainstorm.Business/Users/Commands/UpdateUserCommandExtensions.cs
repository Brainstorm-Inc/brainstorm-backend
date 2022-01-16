using Brainstorm.Business.Users.Commands;
using Brainstorm.Entities.User;

namespace Brainstorm.Business.Users.Commands;

public static class UpdateUserCommandExtensions
{
    public static User ToUser(this UpdateUserCommand command)
    {
        return new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            ProfilePicture = command.ProfilePicture
        };
    }
}