using Gateway.API.Queries.Catalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [ApiController]
    [Route("gateway/[controller]")]
    public class QueryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QueryController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetProducts")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }
    }
}
