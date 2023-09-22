

namespace Lab.APIGateway.Order
{
    public class OrderService : IOrderService
    {
        private static readonly List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, UserId = 1, ProductIds = new List<int>(){ 1, 2 } },
            new Order { OrderId = 2, UserId = 2, ProductIds = new List<int>(){ 1 } },
            // Добавьте еще заказов при необходимости
        };

        public List<Order> GetOrdersByUserId(int userId)
        {
            return orders.FindAll(order => order.UserId == userId);
        }

        public List<Order> GetOrdersByProductId(int productId)
        {
            return orders.FindAll(order => order.ProductIds != null && order.ProductIds.Contains(productId));
        }
    }
}
