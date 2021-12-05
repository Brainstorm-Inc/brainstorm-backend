using System;
using System.Collections.Generic;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities.User;
using MediatR;

namespace Brainstorm.Business.Organization.Commands
{
    public class CreateOrganizationCommand : IRequest<CreateOrganizationResponse>
    {
        public string Name { get; init; }
        
        public ICollection<User> Users { get; init; }
        
        public string LogoLink { get; init; }

        public Guid CreatorId { get; init; }
    }
}