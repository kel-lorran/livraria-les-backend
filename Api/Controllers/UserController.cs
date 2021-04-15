using System.Threading.Tasks;
using Api.Services;
using Domain.UserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<GenericCommandResult>> Authenticate(
            [FromBody]LoginCommand command,
            [FromServices]UserHandler handler
        )
        {
            var result = (GenericCommandResult) handler.Handle(command);
            if (result.Success && result.Data != null)
            {
                var user = (User) result.Data;
                var token = TokenService.GenerateToken(user);
                return Ok(new { token = token, email = user.Email });
            }
            if (result.Data == null)
                return NotFound(result);

            return BadRequest(result);
        }
    }
}