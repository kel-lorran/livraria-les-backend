using System.Collections.Generic;
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
        [HttpPut]
        [Authorize(Roles = "manager")]
        [Route("{id:int}")]
        public async Task<ActionResult<GenericCommandResult>> Update(
            [FromBody]UpdateBookCommand command,
            [FromServices]ProductHandler handler,
            [FromServices]IProductRepository repository,
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
        [HttpPut]
        [Authorize(Roles = "manager")]
        [Route("status/{id:int}")]
        public async Task<ActionResult<GenericCommandResult>> Update(
            [FromBody]UpdateStatusBookCommand command,
            [FromServices]ProductHandler handler,
            [FromServices]IProductRepository repository,
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
        [HttpGet]
        [Authorize(Roles = "manager")]
        [Route("active")]
        public async Task<ActionResult<List<Book>>> GetAllActive(
            [FromServices]IProductRepository repository
        )
        {
            return repository.GetAllActive();
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        [Route("inactive")]
        public async Task<ActionResult<List<Book>>> GetAllInactive(
            [FromServices]IProductRepository repository
        )
        {
            return repository.GetAllInactive();
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        [Route("{id:int}")]
        public async Task<ActionResult<Book>> GetById(
            [FromServices]IProductRepository repository,
            int id
        )
        {
            return repository.GetById(id);
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        [Route("search")]
        public async Task<ActionResult<List<Book>>> Search(
            [FromServices]IProductRepository repository,
            [FromQuery]int? active,
            [FromQuery]string author,
            [FromQuery]string title,
            [FromQuery]int? category,
            [FromQuery]string publishing,
            [FromQuery]string edition,
            [FromQuery]string isbn,
            [FromQuery]int? year,
            [FromQuery]int? pageNumber,
            [FromQuery]string synopsis,
            [FromQuery]int? height,
            [FromQuery]int? width,
            [FromQuery]int? weight,
            [FromQuery]int? length,
            [FromQuery]int? pricingGroup,
            [FromQuery]string codeBar
        )
        {
            return repository.Search(
                active,
                author,
                title,
                category,
                publishing,
                edition,
                isbn,
                year,
                pageNumber,
                synopsis,
                height,
                width,
                weight,
                length,
                pricingGroup,
                codeBar
            );
        }
    }
}