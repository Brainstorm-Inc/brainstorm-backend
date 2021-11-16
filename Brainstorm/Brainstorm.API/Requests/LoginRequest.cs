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
            RuleFor(r => r.Email).NotEmpty()
                .EmailAddress().WithMessage("Wrong email format");
            RuleFor(r => r.Password).NotEmpty()
                .MinimumLength(6).WithMessage("Password is too short.");
        }
    }
}