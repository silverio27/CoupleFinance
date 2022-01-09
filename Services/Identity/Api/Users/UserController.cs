using System;
using System.Net;
using System.Threading.Tasks;
using Api.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Users
{
    [Authorize]
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        IMediator _mediator;
        IUsersQuery _query;

        public UserController(IMediator mediator, IUsersQuery query)
        {
            _mediator = mediator;
            _query = query;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserView>> Get(Guid id)
        {
            return await _query.Get(id);
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<UserView>>> Get([FromQuery] UserQueryParams queryParams)
        {
            return await _query.Get(queryParams);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Response>> Create(NewUser user)
        {
            var response = await _mediator.Send(user);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Response>> Update(UpdateUser user)
        {
            var response = await _mediator.Send(user);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }
}