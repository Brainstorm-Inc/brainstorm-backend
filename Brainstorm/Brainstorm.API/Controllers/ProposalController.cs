using System;
using System.Threading.Tasks;
using Brainstorm.API.Requests;
using Brainstorm.Business.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brainstorm.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProposalController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProposalController(IMediator mediator)
    {
        _mediator = mediator;
    }
        
    [HttpGet("{proposalId}")]
    public async Task<ActionResult<string>> GetProposal(string proposalId) {
        var res = await _mediator.Send(new GetProposalQuery(){Id = Guid.Parse(proposalId)});
        return Ok(res);
    }
}

