namespace Lab.APIGateway.Product
{
    public interface IProductService
    {
        Product? GetProductById(int userId);
        List<Product> GetProducts();
    }
}
