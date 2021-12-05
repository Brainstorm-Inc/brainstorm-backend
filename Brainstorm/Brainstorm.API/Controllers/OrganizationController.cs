using System.Threading.Tasks;
using Brainstorm.API.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brainstorm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrganizationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("/Org/{creatorId}")]
        public async Task<ActionResult> CreateOrganization([FromBody] CreateOrganizationRequest request,string creatorId)
        {
            var res = await _mediator.Send(request.ToCommand(creatorId));
            return Ok(res);
        }

    }
}