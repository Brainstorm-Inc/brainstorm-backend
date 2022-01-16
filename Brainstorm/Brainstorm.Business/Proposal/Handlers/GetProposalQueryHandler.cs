using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Users.Queries;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities;
using Brainstorm.Entities.Proposal;
using MediatR;

namespace Brainstorm.Business.Users.Handlers;

public class GetProposalQueryHandler : IRequestHandler<GetProposalQuery, Proposal>
{
    private readonly BrainstormContext _ctx;

    public GetProposalQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<Proposal> Handle(GetProposalQuery request, CancellationToken cancellationToken)
    {
        if (!_ctx.Users.Any())
        {
            throw new Exception("No user found.");
        }

        var proposal = _ctx.Proposals
            .FirstOrDefault(p => p.Id == request.Id);
        
        return Task.FromResult(proposal);
    }
}