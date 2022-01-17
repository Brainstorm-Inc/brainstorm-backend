using System.Collections.Generic;

namespace Brainstorm.Entities.Timeline;

public class Timeline : BaseEntity
{
    public List<Proposal.Proposal> Proposals { get; init; }
}