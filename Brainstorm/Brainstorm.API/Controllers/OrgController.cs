using System;
using System.Threading.Tasks;
using Brainstorm.API.Requests;
using Brainstorm.Business.Organization.Commands;
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

    [HttpPost("{creatorId}")]
    public async Task<ActionResult> CreateOrganization([FromBody] CreateOrganizationRequest request,
        [FromRoute] string creatorId)
    {
        var res = await _mediator.Send(request.ToCommand(creatorId));
        return Ok(res);
    }

    [HttpGet("{orgId}")]
    public async Task<ActionResult> GetOrganizationInfo(string orgId)
    {
        var res = await _mediator.Send(new GetOrganizationInfoQuery {Id = new Guid(orgId)});

        return Ok(res);
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

    [HttpPost("{orgId}/user/{userId}")]
    public async Task<ActionResult> AddUserToOrg([FromRoute] string orgId, [FromRoute] string userId)
    {
        await _mediator.Send(new AddUserToOrgQuery {OrgId = orgId, UserId = userId});

        return Created("", null);
    }

    [HttpDelete("{orgId}/user/{userId}")]
    public async Task<ActionResult> RemoveUserFromOrg([FromRoute] string orgId, [FromRoute] string userId)
    {
        await _mediator.Send(new RemoveUserFromOrgQuery {OrgId = orgId, UserId = userId});

        return Accepted();
    }


    [HttpDelete("{orgId}")]
    public async Task<ActionResult> DeleteOrg([FromRoute] string orgId)
    {
        await _mediator.Send(new DeleteOrganizationCommand {OrgId = Guid.Parse(orgId)});
        return Accepted();
    }

    [HttpPut("{orgId}")]
    public async Task<ActionResult> UpdateOrg([FromRoute] string orgId, [FromBody] UpdateOrgRequest request)
    {
        var res = await _mediator.Send(request.ToCommand(Guid.Parse(orgId)));
        return Ok(res);
    }

    [HttpPost("{orgId}/project")]
    public async Task<ActionResult> CreateProjectInOrg([FromRoute] string orgId,
        [FromBody] CreateProjectInOrgRequest request)
    {
        var res = await _mediator.Send(request.ToCommand(Guid.Parse(orgId)));

        return Created("", res);
    }

    [HttpGet("{orgId}/projects")]
    public async Task<ActionResult> GetOrgProjects([FromRoute] string orgId)
    {
        var res = await _mediator.Send(new GetOrgProjectsQuery {OrgId = Guid.Parse(orgId)});
        
        return Ok(res);
    }
}