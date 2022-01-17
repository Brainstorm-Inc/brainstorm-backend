using System;

namespace Brainstorm.Entities.Comment;

public class Comment : BaseEntity
{
    public string Content { get; init; }
    public DateTime CreationDate { get; init; }

    public User.User Author { get; init; }
    public Comment ReplyTo { get; init; }
    public Proposal.Proposal Proposal { get; init; }
}