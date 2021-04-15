using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.CustomerContext;
using Domain.UserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api
{
    [ApiController]
    [Route("v1/customer")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody]CreateCustomerCommand command,
            [FromServices]CustomerHandler handler,
            [FromServices]UserHandler userHandler
        )
        {
            var userResult = (GenericCommandResult) userHandler.Handle(new CreateUserCommand(command.Email, command.Password, "customer"));
            if (userResult.Data != null)
            {
                var result = (GenericCommandResult) handler.Handle(command);
                var customer = (Customer) result.Data;
                return Ok(customer);
            }

            return BadRequest(userResult);
        }

        [HttpGet]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Customer>>> GetAll(
            [FromServices]ICustomerRepository repository
        )
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("own-profile")]
        [Authorize]
        public async Task<ActionResult<Customer>> ReadOwnProfile(
            [FromServices]ICustomerRepository repository
        )
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value;
            var customer = repository.GetByEmail(email);
            if(customer != null)
                return Ok(customer);
            return NotFound();
        }

        [HttpPut]
        [Route("person-data")]
        [Authorize]
        public async Task<ActionResult<GenericCommandResult>> UpdatePersonData (
            [FromBody]UpdateCustomerPersonDataCommand command,
            [FromServices]CustomerHandler handler
        )
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value;
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;

            if(email != command.Email && role != "manager")
                return Unauthorized();
            
            var result = handler.Handle(command);
            return Ok(result);
        }
        [HttpPost]
        [Route("add-address")]
        [Authorize]
         public async Task<ActionResult<GenericCommandResult>> AddAddress (
            [FromBody]CreateCustomerAddresCommand command,
            [FromServices]CustomerHandler handler
        )
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value;
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            command.SetAuthEmail(email);
            command.SetAuthRole(role);
            
            var result = (GenericCommandResult) handler.Handle(command);
            if(result == null)
                return Unauthorized();

            if(result.Data == null)
                return NotFound(result);
            
            return Ok(result);
        }
        [HttpPost]
        [Route("add-credit-card")]
        [Authorize]
         public async Task<ActionResult<GenericCommandResult>> AddCreditCard (
            [FromBody]CreateCustomerCreditCardCommand command,
            [FromServices]CustomerHandler handler
        )
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value;
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            command.SetAuthEmail(email);
            command.SetAuthRole(role);
            
            var result = (GenericCommandResult) handler.Handle(command);
            if(result == null)
                return Unauthorized();

            if(result.Data == null)
                return NotFound(result);
            
            return Ok(result);
        }
    }
}