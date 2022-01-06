using Brainstorm.Entities.User;

namespace Brainstorm.Business.Auth.Commands;

public static class SignupCommandExtensions
{
    public static User ToUser(this SignupCommand command, string salt)
    {
        return new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            ProfilePicture = $"https://robohash.org/{command.FirstName}-{command.LastName}.png",
            Salt = salt
        };
    }
}
