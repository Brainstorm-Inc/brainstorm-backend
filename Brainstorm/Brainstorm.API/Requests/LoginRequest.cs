using System.Data;
using FluentValidation;

namespace Brainstorm.API.Requests
{
    public class LoginRequest
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("Wrong email format.");
            RuleFor(r => r.Password)
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}