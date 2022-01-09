using System.Net;
using System.Threading.Tasks;
using Api.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Auth
{
    [Authorize]
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Response>> GetToken(Credential credential)
        {
            var response = await _mediator.Send(credential);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        
        }
        [HttpPost("recovery-password")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Response>> RecoveryPassword(UserRequestNewPassword requestNewPassword)
        {
            var response = await _mediator.Send(requestNewPassword);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("change-password")]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Response>> ChangePassword(NewPassword newPassword)
        {
            var response = await _mediator.Send(newPassword);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

    }
}