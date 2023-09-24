using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace Lab.APIGateway.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly ILogger<OrdersModel> _logger;

        private readonly IHttpClientFactory _httpClientFactory;
        public List<Order> orders { get; set; }
        public List<Product> products { get; set; }
        public OrdersModel(ILogger<OrdersModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OnGet()
        {
            var ProductHttpClient = _httpClientFactory.CreateClient("ProductMicroservice");
            var OrderHttpClient = _httpClientFactory.CreateClient("OrderMicroservice");

            var responseOrder = await OrderHttpClient.GetAsync("Order/user/1");
            var responseProduct = await ProductHttpClient.GetAsync("api/products");

            if (responseProduct.IsSuccessStatusCode)
            {
                var response = await responseProduct.Content.ReadAsStringAsync();
                _logger.LogInformation(response);
                products = JsonConvert.DeserializeObject<List<Product>>(response) ?? new List<Product>();

            }

            if (responseOrder.IsSuccessStatusCode)
            {
                var response = await responseOrder.Content.ReadAsStringAsync();
                _logger.LogInformation(response);
                orders = JsonConvert.DeserializeObject<List<Order>>(response) ?? new List<Order>();
            }
            return Page();
        }
        public Product? GetProductById(int productId)
        {
            return products.Find(product => product.ProductId == productId);
        }
        public async Task<User?> GetUserById(int userId)
        {
            var UserHttpClient = _httpClientFactory.CreateClient("UserMicroservice");
            var responseUser = await UserHttpClient.GetAsync(requestUri: "api/users/" + userId);
            var response = await responseUser.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(response);
        }
       
    }
}