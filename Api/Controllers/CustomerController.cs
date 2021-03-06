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
            var validationResult = command.Validate();
            if (!validationResult.Success)
                return BadRequest(validationResult);
                
            var userResult = (GenericCommandResult) userHandler.Handle(new CreateUserCommand(command.Email, command.Password, "customer"));

            if (userResult.Success)
            {
                var user = (User) userResult.Data;
                command.SetUserId(user.Id);


                var result = handler.Handle(command);
                return Ok(result);
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
        [Authorize(Roles = "manager")]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> GetById(
            [FromServices]ICustomerRepository repository,
            int id
        )
        {
            return repository.GetById(id);
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
        [HttpGet]
        [Route("search")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<Customer>>> Search(
            [FromServices]ICustomerRepository repository,
            [FromQuery]string name,
            [FromQuery]string lastName,
            [FromQuery]string gender,
            [FromQuery]string cpf,
            [FromQuery]string birthDate,
            [FromQuery]string phone,
            [FromQuery]string email,
            [FromQuery]int? active
        )
        {
            return repository.Search(
                name,
                lastName,
                gender,
                cpf,
                birthDate,
                phone,
                email,
                active
            );
        }

        [HttpPut]
        [Route("person-data")]
        [Authorize]
        public async Task<ActionResult<GenericCommandResult>> UpdatePersonData (
            [FromBody]UpdateCustomerPersonDataCommand command,
            [FromServices]CustomerHandler handler,
            [FromServices]ICustomerRepository repository
        )
        {
            var email = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value;
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;

            var customer = repository.GetByEmail(command.Email);
            command.MergeEntity(customer);

            if(email != command.Email && role != "manager")
                return Unauthorized();

            var validationResult = command.Validate();
            if (!validationResult.Success)
                return BadRequest(validationResult);
            
            var result = handler.Handle(command);
            return Ok(result);
        }
        [HttpPut]
        [Authorize(Roles = "manager")]
        [Route("status/{id:int}")]
        public async Task<ActionResult<GenericCommandResult>> Update(
            [FromBody]UpdateStatusCustomerCommand command,
            [FromServices]CustomerHandler handler,
            [FromServices]ICustomerRepository repository,
            int id
        )
        {
            var book = repository.GetById(id);
            if (book == null)
                return BadRequest();

            command.MergeEntity(book);

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
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            var customerId = int.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value);

            if(command.CustomerId == 0)
                command.CustomerId = customerId;

            if(customerId != command.CustomerId && role != "manager")
                return Unauthorized();

            var validationResult = command.Validate();
            if (!validationResult.Success)
                return BadRequest(validationResult);
            
            var result = (GenericCommandResult) handler.Handle(command);

            if(result.Data == null)
                return NotFound(result);
            
            return Ok(result);
        }
        [HttpDelete]
        [Route("remove-address")]
        [Authorize]
         public async Task<ActionResult<GenericCommandResult>> removeAddress (
            [FromBody]RemoveCustomerAddresCommand command,
            [FromServices]CustomerHandler handler
        )
        {
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            var customerId = int.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value);

            if(command.CustomerId == 0)
                command.CustomerId = customerId;

            if(customerId != command.CustomerId && role != "manager")
                return Unauthorized();
            
            var result = (GenericCommandResult) handler.Handle(command);

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
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            var customerId = int.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value);

            if(command.CustomerId == 0)
                command.CustomerId = customerId;

            if(customerId != command.CustomerId && role != "manager")
                return Unauthorized();

            var validationResult = command.Validate();
            if (!validationResult.Success)
                return BadRequest(validationResult);
            
            var result = (GenericCommandResult) handler.Handle(command);

            if(result.Data == null)
                return NotFound(result);
            
            return Ok(result);
        }
    }
}