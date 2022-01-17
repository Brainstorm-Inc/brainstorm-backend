using System;

namespace Brainstorm.Business.Organization.Responses;

public class UpdateOrganizationResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Logo { get; init; }
}