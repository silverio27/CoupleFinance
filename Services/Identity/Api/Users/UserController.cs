using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Users
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Response>> Create(NewUser user)
        {
            var response = await _mediator.Send(user);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }
}