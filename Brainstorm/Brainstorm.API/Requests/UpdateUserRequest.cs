using System;
using FluentValidation;

namespace Brainstorm.API.Requests;

public class UpdateUserRequest
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    
    public string ProfilePicture { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(r => r.FirstName).NotEmpty();
        RuleFor(r => r.LastName).NotEmpty();
        RuleFor(r => r.Email).NotEmpty()
            .EmailAddress().WithMessage("Wrong email format");
        RuleFor(r => r.Password).NotEmpty()
            .MinimumLength(6).WithMessage("Password is too short.");
    }
}