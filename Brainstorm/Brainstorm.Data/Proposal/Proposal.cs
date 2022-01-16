using System;
using System.Collections.Generic;

namespace Brainstorm.Entities.Proposal;

public class Proposal
{
   public Guid Id { get; init; } 
   public string Description { get; init; }
   public DateTime CreationDate { get; init; }
   public List<string> Files { get; init; }
   
   public User.User Author { get; init; }
   public List<Comment.Comment> Comments { get; init; }
   public Rating.Rating Rating { get; init; }
   
   
}