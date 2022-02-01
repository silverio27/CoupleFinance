using System;
using System.Collections.Generic;
using System.Linq;
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

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

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

        [HttpGet]
        public IActionResult ActiveAccount(){
            Uri uri = new("www.google.com");
            return Content("window.location.href = https://www.google.com", "application/x-javascript; charset=utf-8");
        }


    }
}