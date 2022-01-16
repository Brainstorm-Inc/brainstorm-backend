using System;
using System.Collections.Generic;

namespace Brainstorm.Entities.Topic;

public class Topic
{
    public Guid Id { get; init; }
    public string Type { get; init; }
    public string Title { get; init; }
    public DateTime CreationDate { get; init; }

    public User.User Author { get; init; }
    public Proposal.Proposal HighlightedProposal { get; init; }
    public List<User.User> Users { get; init; }
    public Iteration.Iteration CurrentIteration { get; init; }
    public List<Iteration.Iteration> Iterations { get; init; }
    public Project.Project Project { get; init; }
}