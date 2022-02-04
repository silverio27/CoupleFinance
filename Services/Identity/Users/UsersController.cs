using System;
using System.Linq;
using System.Threading.Tasks;
using Identity.Users.Commands;
using Identity.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IMediator _mediator;

        public UsersController(SignInManager<User> signInManager, IMediator mediator)
        {
            _signInManager = signInManager;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _signInManager.UserManager.Users.Select(x=>new UserView(){
                Email = x.Email,
                Id = x.Id,
                Name = x.UserName
            }).FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewUserRequest request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetById), new { Id = result.Data.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserRequest request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
                return NotFound();
            await _signInManager.UserManager.DeleteAsync(user);
            return NoContent();
        }

    }
}