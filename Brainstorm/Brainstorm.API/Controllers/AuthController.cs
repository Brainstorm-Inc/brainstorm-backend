using System;
using System.Threading.Tasks;
using Brainstorm.API.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brainstorm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult> Signup([FromBody] SignupRequest request)
        {
            var res = await _mediator.Send(request.ToCommand());
            return Ok(res);
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var res = await _mediator.Send(request.ToQuery());

            return Ok(res);
        }
    }
}