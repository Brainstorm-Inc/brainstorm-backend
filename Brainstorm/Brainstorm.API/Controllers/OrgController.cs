using System.Threading.Tasks;
using Brainstorm.API.Requests;
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

    [HttpGet("{orgId}/user/{userId}")]
    public async Task<ActionResult> CheckUserInOrg([FromRoute] string orgId, [FromRoute] string userId)
    {
        await _mediator.Send(new CheckUserInOrgQuery {OrgId = orgId, UserId = userId});

        return NoContent();
    }
    
    [HttpPost("{orgId}/update/{creatorId}")] //Aici e ok ????
    public async Task<ActionResult> UpdateOrganizationInfo([FromBody] UpdateOrgInfoRequest request,string creatorId)
    {
        var res = await _mediator.Send(request.ToCommand(creatorId));
        return Ok(res);
    }
}