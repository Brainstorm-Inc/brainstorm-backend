using System;

namespace Brainstorm.Entities.Comment;

public class Comment
{
    public Guid Id { get; init; }
    public User.User Author { get; init; }
    public string Content { get; init; }
    public DateTime CreationDate { get; init; }

    public Comment ReplyTo { get; init; }
    public Proposal.Proposal Proposal { get; init; }
}