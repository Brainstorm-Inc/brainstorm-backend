using FluentValidation;

namespace Brainstorm.API.Requests
{
    public class LoginRequest
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}