namespace Lab.APIGateway.Order
{
    public interface IOrderService
    {
        List<Order> GetOrdersByUserId(int userId);
        List<Order> GetOrdersByProductId(int productId);
    }
}
