using System;
using System.Collections.Generic;

namespace Brainstorm.Entities.Iteration;

public class Iteration : BaseEntity
{
    public uint Position { get; init; }
    public bool IsOpen { get; init; }
    public string Goal { get; init; }
    public string Description { get; init; }
    public List<string> Files { get; init; }
    public DateTime Deadline { get; init; }

    public List<Comment.Comment> Comments { get; init; }
    public Timeline.Timeline Timeline { get; init; }
    public Topic.Topic Topic { get; set; }
}