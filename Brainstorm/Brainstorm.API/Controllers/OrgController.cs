using System;
using System.Threading.Tasks;
using Brainstorm.API.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brainstorm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrgController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrgController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("{creatorId}")]
        public async Task<ActionResult> CreateOrganization([FromBody] CreateOrganizationRequest request,string creatorId)
        {
            var res = await _mediator.Send(request.ToCommand(creatorId));
            return Ok(res);
        }

    }
}