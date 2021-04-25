using System.Threading.Tasks;
using Domain.MerchandiseContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api
{
    [ApiController]
    [Route("v1/product")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody]CreateBookCommand command,
            [FromServices]ProductHandler handler
        )
        {
            var result = handler.Handle(command);
            return Ok(result);
        }
    }
}