    using FluentValidation;

    namespace Brainstorm.API.Requests;

    public class DeleteOrganizationRequest
    {
        public string CreatorId { get; init; }
    }

    public class DeleteOrganizationValidator : AbstractValidator<DeleteOrganizationRequest>
    {
        public DeleteOrganizationValidator()
        {
            RuleFor(r => r.CreatorId).NotEmpty();
        }
    }
