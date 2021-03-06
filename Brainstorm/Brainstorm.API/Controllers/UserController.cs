using System;
using System.Threading.Tasks;
using Brainstorm.API.Requests;
using Brainstorm.Business.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brainstorm.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
        
    [HttpGet("{userId}")]
    public async Task<ActionResult<string>> GetUser(string userId) {
        var res = await _mediator.Send(new GetUserQuery{UserId = Guid.Parse(userId)});
        return Ok(res);
    }
    
    [HttpGet("{userId}/orgs")]
    public async Task<ActionResult<string>> GetOrgsForUser(string userId) {
        var res = await _mediator.Send(new GetUserOrgsQuery(){UserId = Guid.Parse(userId)});
        return Ok(res);
    }
    
    [HttpPut("{userId}")]
    public async Task<ActionResult<string>> UpdateUser([FromRoute] string userId, [FromBody] UpdateUserRequest request) {
        var id = Guid.Parse(userId);
        var res = await _mediator.Send(request.ToCommand(id));
        return Ok(res);
    }
}

