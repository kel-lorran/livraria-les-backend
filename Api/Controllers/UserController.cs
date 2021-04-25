using System.Threading.Tasks;
using Api.Services;
using Domain.CustomerContext;
using Domain.UserContext;
using Infra;
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
            [FromServices]IUserRepository repository,
            [FromServices]ICustomerRepository customerRepository
        )
        {
            var user = repository.GetByUserAndPassword(command.Email, command.Password);
            var customer = customerRepository.GetByUserId(user.Id);
            if (user != null && customer != null)
            {
                var token = TokenService.GenerateToken(user, customer);
                return Ok(new { token = token, email = user.Email });
            }
            return NotFound();
        }
    }
}