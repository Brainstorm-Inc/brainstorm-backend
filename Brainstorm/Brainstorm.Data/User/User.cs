namespace Brainstorm.Entities.User;

public class User : BaseEntity
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string ProfilePicture { get; init; }

    public Organization.Organization Org { get; set; }
}