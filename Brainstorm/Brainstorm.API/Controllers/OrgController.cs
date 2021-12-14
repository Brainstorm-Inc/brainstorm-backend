using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brainstorm.API.Controllers;

[ApiController]
[Route("api/{controller}")]
public class OrgController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrgController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{orgId}/users")]
    public async Task<ActionResult> GetOrgMembers([FromRoute] string orgId)
    {
        var res = await _mediator.Send(new GetOrgMembersQuery {OrgId = orgId});

        return Ok(res);
    }
}