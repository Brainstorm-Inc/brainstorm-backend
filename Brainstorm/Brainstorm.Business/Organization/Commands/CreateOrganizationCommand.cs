using System;
using Brainstorm.Business.Organization.Responses;
using MediatR;

namespace Brainstorm.Business.Organization.Commands
{
    public class CreateOrganizationCommand : IRequest<CreateOrganizationResponse>
    {
        public string Name { get; init; }
        
        public string LogoLink { get; init; }

        public Guid CreatorId { get; init; }
    }
}