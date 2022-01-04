using System;

namespace Brainstorm.Business.Auth.Responses;

public class SignupResponse
{
    public string Token { get; init; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePicture { get; set; }
    public Guid Id { get; set; }
}