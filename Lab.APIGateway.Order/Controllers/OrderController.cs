
using Microsoft.AspNetCore.Mvc;

namespace Lab.APIGateway.Order.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOrdersByUserId(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid userId");
            }

            var orders = orderService.GetOrdersByUserId(userId);

            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found for the specified user");
            }

            return Ok(orders);
        }

        [HttpGet("product/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOrdersByProductId(int productId)
        {
            if (productId <= 0)
            {
                return BadRequest("Invalid productId");
            }

            var orders = orderService.GetOrdersByProductId(productId);

            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found for the specified product");
            }

            return Ok(orders);
        }
    }
}