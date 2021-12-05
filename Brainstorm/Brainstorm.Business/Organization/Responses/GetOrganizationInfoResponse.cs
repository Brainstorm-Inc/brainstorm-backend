using System;
using System.Collections.Generic;
using Brainstorm.Entities.User;

namespace Brainstorm.Business.Organization.Responses
{
    public class GetOrganizationInfoResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<User> Users { get; set; }
        
        public string Logo { get; set; }
    }
}