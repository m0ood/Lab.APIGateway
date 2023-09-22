
namespace Lab.APIGateway.Order
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public List<int>? ProductIds { get; set; }
    }
}
