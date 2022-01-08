using System.Net;
using System.Threading.Tasks;
using Api.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Auth
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Response>> GetToken(Credential credential)
        {
            var response = await _mediator.Send(credential);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}