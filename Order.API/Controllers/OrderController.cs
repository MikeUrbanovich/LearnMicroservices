using Microsoft.AspNetCore.Mvc;
using Order.API.Data;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpGet("GetOrders")]
        //[Authorize(Roles = "Admin")]
        public IEnumerable<Data.Order> GetOrders()
        {
            return _dataContext.Orders;
        }

        [HttpPost("AddOrder")]
        public IEnumerable<Data.Order> AddProduct(Data.Order newOrder)
        {
            if (!_dataContext.Orders.Contains(newOrder))
                _dataContext.Orders.Add(newOrder);

            return _dataContext.Orders;
        }
    }
}