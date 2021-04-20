using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.MerchandiseContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    [ApiController]
    [Route("v1/merchandise")]
    public class MerchandiseController : ControllerBase
    {
        [HttpPost]
        [Route("increment")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<Merchandise>> Create(
            [FromBody]IncrementMerchandiseStockCommand command,
            [FromServices]IProductRepository productRepository,
            [FromServices]MerchandiseHandler handler
        )
        {
            var book = productRepository.GetById(command.BookId);
            command.SetBook(book);
            var result = handler.Handle(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("decrement")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<Merchandise>> Create(
            [FromBody]DecrementMerchandiseStockCommand command,
            [FromServices]IProductRepository productRepository,
            [FromServices]MerchandiseHandler handler
        )
        {
            var book = productRepository.GetById(command.BookId);
            command.SetBook(book);
            var result = handler.Handle(command);

            return Ok(result);
        }
        [HttpGet]
        [Route("active")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Merchandise>>> GetAllActive(
            [FromServices]IMerchandiseRepository repository
        )
        {
            var result = repository.GetAllActive();
            return result;
        }
    }
}