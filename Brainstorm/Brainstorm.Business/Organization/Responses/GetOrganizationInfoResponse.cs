using System;
using System.Collections.Generic;

namespace Brainstorm.Business.Organization.Responses
{
    public class GetOrganizationInfoResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<Guid> UserIds { get; set; }
        
        public string Logo { get; set; }
    }
}