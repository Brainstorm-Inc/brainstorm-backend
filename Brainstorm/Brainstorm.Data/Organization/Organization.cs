using System.Collections.Generic;
using Brainstorm.Entities.User;

namespace Brainstorm.Entities.Organization;

public class Organization : BaseEntity
{
    public string Name { get; set; }

    // TODO list of projects
    public string LogoLink { get; set; }

    public ICollection<User.User> Users { get; init; }
}