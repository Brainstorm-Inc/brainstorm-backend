using FluentValidation;

namespace Brainstorm.API.Requests;

public class UpdateOrgInfoRequest
{
    public string Name { get; init; }
        
    public string Logo { get; init; }
    
    public string UserId { get; init; }

}

public class UpdateOrgInfoValidator : AbstractValidator<UpdateOrgInfoRequest>
{
    public UpdateOrgInfoValidator()
    {
        
    }
}