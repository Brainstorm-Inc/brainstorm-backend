using System;
using System.Collections.Generic;

namespace Brainstorm.Entities.Project;

public class Project
{
    public Guid Id { get; init; }
    public string Name { get; init; }

    public List<Topic.Topic> Topics { get; init; }
}