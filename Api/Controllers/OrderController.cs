using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.MerchandiseContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    [ApiController]
    [Route("v1/order")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> Create(
            [FromBody]CreateOrderCommand command,
            [FromServices]OrderHandler handler
        )
        {
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            var customerId = int.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value);

            if(customerId != command.CustomerId && role != "manager")
                return Unauthorized();
            
            var result = handler.Handle(command);
            return Ok(result);
        }
    }
}