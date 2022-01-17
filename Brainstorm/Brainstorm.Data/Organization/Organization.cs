using System.Collections.Generic;
using Brainstorm.Entities.User;

namespace Brainstorm.Entities.Organization;

public class Organization : BaseEntity
{
    public string Name { get; set; }

    public string LogoLink { get; set; }

    public ICollection<Project.Project> Projects { get; init; }
    public ICollection<User.User> Users { get; init; }
}