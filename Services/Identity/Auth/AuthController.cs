using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Success) return Ok(result);
            if (result.Message == "Usuário não encontrado") return NotFound(result);

            return BadRequest(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("active-account")]
        public async Task<IActionResult> ActiveAccount(ActiveAccountRequest request)
        {

            var result = await _mediator.Send(request);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost("request-new-password")]
        public async Task<IActionResult> RequestNewPassword(TokenResetPasswordRequest request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }


    }
}