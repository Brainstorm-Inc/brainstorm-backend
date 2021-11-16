using FluentValidation;

namespace Brainstorm.API.Requests
{
    public class SignupRequest
    {
        
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public class SignupRequestValidator : AbstractValidator<SignupRequest>
    {
        public SignupRequestValidator()
        {
            RuleFor(r => r.FirstName)
                .MinimumLength(6).WithMessage("Wrong first name format.");
            RuleFor(r => r.LastName)
                .MinimumLength(6).WithMessage("Wrong last name format.");
            RuleFor(r => r.Email)
               .EmailAddress().WithMessage("Wrong email format.");
            RuleFor(r => r.Password)
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
