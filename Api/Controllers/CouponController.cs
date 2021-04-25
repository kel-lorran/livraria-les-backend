using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.MerchandiseContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api
{
    [ApiController]
    [Route("v1/coupon")]
    public class CouponController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody]CreateCouponCommand command,
            [FromServices]CouponHandler handler
        )
        {
            var result = handler.Handle(command);
            return Ok(result);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Coupon>>> GetAll(
            [FromServices]ICouponRepository repository
        )
        {
            var role = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            var customerId = int.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value);

            if(role == "manager")
                return Ok(repository.GetAll());
            return Ok(repository.GetByCustomerId(customerId));
        }
    }
}