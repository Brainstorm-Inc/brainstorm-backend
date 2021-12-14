using System.Threading.Tasks;
using Brainstorm.Business.AppVersions.Queries;
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

    [HttpGet("user")]
    public async Task<ActionResult<string>> GetUser()
    {
        var res = await _mediator.Send(new GetUserQuery());
        return Ok(res);
    }
}