using System;
using System.Collections.Generic;

namespace Brainstorm.Entities.Iteration;

public class Iteration
{
    public Guid Id { get; init; }
    public uint Position { get; init; }
    public bool IsOpen { get; init; }
    public string Goal { get; init; }
    public string Description { get; init; }
    public List<string> Files { get; init; }

    public List<Comment.Comment> Comments { get; init; }
    public DateTime Deadline { get; init; }
    public Timeline.Timeline Timeline { get; init; }
}