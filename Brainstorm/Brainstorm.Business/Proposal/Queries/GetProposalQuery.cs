using System;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities.Proposal;
using MediatR;

namespace Brainstorm.Business.Users.Queries;

public class GetProposalQuery : IRequest<Proposal>
{
    public Guid Id { get; init; }
}