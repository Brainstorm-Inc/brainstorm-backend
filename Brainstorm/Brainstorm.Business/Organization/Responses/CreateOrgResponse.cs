using System;
using System.Collections.Generic;
using Brainstorm.Entities.User;

namespace Brainstorm.Business.Organization.Responses
{
    public class CreateOrgResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LogoLink { get; set; }
        public ICollection<User> Users { get; init; }
    }
}