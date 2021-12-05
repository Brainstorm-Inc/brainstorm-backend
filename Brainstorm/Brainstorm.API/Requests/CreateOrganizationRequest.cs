using FluentValidation;

namespace Brainstorm.API.Requests
{
    public class CreateOrganizationRequest
    {
        public string Name { get; init; }
        
        public string Logo { get; init; }

    }

    public class CreateOrganizationValidator : AbstractValidator<CreateOrganizationRequest>
    {
        public CreateOrganizationValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}