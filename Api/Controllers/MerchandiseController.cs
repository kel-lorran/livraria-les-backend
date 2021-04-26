using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.MerchandiseContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api
{
    [ApiController]
    [Route("v1/merchandise")]
    public class MerchandiseController : ControllerBase
    {
        [HttpPost]
        [Route("increment")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<GenericCommandResult>> Create(
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
        public async Task<ActionResult<GenericCommandResult>> Create(
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
        public async Task<ActionResult<List<StockMerchandise>>> GetAllActive(
            [FromServices]IMerchandiseRepository repository
        )
        {
            return repository.GetAllActive();
        }
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<StockMerchandise>> GetById(
            [FromServices]IMerchandiseRepository repository,
            int id
        )
        {
            return repository.GetById(id);
        }
    }
}