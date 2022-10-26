using Catalog.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpGet("GetProducts")]
        //[Authorize(Roles = "Admin")]
        public IEnumerable<Product> GetProducts()
        {
            return _dataContext.Products;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product newProduct)
        {
            if(!_dataContext.Products.Contains(newProduct))
                _dataContext.Products.Add(newProduct);

            return Ok();
        }

        //[HttpGet("TestGetForUser")]
        ////[Authorize(Roles = "User")]
        //public IActionResult TestGetForUser()
        //{
        //    return Ok("OK");
        //}

        //[HttpGet("TestGet")]
        //public IActionResult TestGet()
        //{
        //    return Ok("OK");
        //}
    }
}