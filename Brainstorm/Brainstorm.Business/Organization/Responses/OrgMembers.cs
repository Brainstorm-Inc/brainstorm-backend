using System.Collections.Generic;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities.User;

namespace Brainstorm.Business.Organization.Responses;

public class OrgMembers
{
    public List<UserDetails> users { get; init; }
}