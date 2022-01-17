using System;
using System.Collections.Generic;

namespace Brainstorm.Entities.Project;

public class Project : BaseEntity
{
    public string Name { get; init; }

    public Organization.Organization Org { get; init; }
    public List<Topic.Topic> Topics { get; init; }
}