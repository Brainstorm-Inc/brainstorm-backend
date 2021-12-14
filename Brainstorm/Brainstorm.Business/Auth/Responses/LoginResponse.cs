using System;

namespace Brainstorm.Business.Auth.Responses;

public class LoginResponse
{
    public string Token { get; init; }
    public string ProfilePicture { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Guid Id { get; set; }
}