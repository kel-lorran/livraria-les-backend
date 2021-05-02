using System;
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
    [Route("v1/order")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GenericCommandResult>> Create(
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
        [HttpPost]
        [AllowAnonymous]
        [Route("draft")]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody]CreateDraftOrderCommand command,
            [FromServices]OrderHandler handler
        )
        {
            var customerId = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            if(customerId != null)
                command.SetCustomerId(int.Parse(customerId));
            
            var result = (GenericCommandResult) handler.Handle(command);
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        [Authorize(Roles = "manager")]
        [Route("status")]
        public async Task<ActionResult<GenericCommandResult>> UpdateStatus(
            [FromBody]UpdateOrderStatusCommand command,
            [FromServices]OrderHandler handler,
            [FromServices]CouponHandler couponHandler
        )
        {
            var result = (GenericCommandResult) handler.Handle(command);
            var order = (Order) result.Data;
            if(result.Success && order.Status.Equals("mercadoria devolvida", StringComparison.OrdinalIgnoreCase))
            {
                couponHandler.Handle(new CreateExchangeCouponCommand(order.CustomerId, order.ExchangedMerchandise));    
            }   
            return Ok(result);
        }
        [HttpPut]
        [Authorize]
        [Route("exchange")]
        public async Task<ActionResult<GenericCommandResult>> UpdateExchangedMerchandise(
            [FromBody]UpdateOrderExchangedMerchandiseCommand command,
            [FromServices]OrderHandler handler,
            [FromServices]CouponHandler couponHandler
        )
        {
            var result = handler.Handle(command);

            return Ok(result);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Order>>> GetAll(
            [FromServices]IOrderRepository repository
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