namespace Lab.APIGateway.Product
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> users = new List<Product>
        {
            new Product { ProductId = 1, Name = "Product A" },
            new Product { ProductId = 2, Name = "Product B" },
        };

        public Product? GetProductById(int productId)
        {
            return users.Find(user => user.ProductId == productId);
        }
    }
}
