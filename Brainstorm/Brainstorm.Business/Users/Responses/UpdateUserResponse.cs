using System;

namespace Brainstorm.Business.Users.Responses;

public class UpdateUserResponse
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePicture { get; set; }
    public Guid Id { get; set; }
} 