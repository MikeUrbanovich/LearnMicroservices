using Gateway.API.Commands.Catalog;
using Gateway.API.Models.Catalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [ApiController]
    [Route("gateway/[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommandController(IMediator mediator) => _mediator = mediator;

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductModel createProductModel)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = createProductModel.Name,
                Cost = createProductModel.Cost
            };

            var result = await _mediator.Send(new CreateProductCommand
            {
                Product = product
            });

            return Ok(result);
        }

    }
}
