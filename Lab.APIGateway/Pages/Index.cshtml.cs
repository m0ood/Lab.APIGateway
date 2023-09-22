using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab.APIGateway.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }
        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OnGet()
        {
            // Создайте HTTP-клиент для нужного микросервиса
            var UserHttpClient = _httpClientFactory.CreateClient("UserMicroservice");

            // Выполните запрос к микросервису
            var responseUser = await UserHttpClient.GetAsync("api/users/1");

            var ProductHttpClient = _httpClientFactory.CreateClient("ProductMicroservice");

            // Выполните запрос к микросервису
            var responseProduct = await ProductHttpClient.GetAsync("api/products/1");

            var OrderHttpClient = _httpClientFactory.CreateClient("ProductMicroservice");

            // Выполните запрос к микросервису
            var responseOrder = await OrderHttpClient.GetAsync("api/Order/user/1");

            if (responseOrder.IsSuccessStatusCode)
            {
                var Orders = await responseOrder.Content.ReadAsStringAsync();
            }
            if (responseUser.IsSuccessStatusCode)
            {
                var User = await responseOrder.Content.ReadAsStringAsync();
            }
            if (responseProduct.IsSuccessStatusCode)
            {
                var Product = await responseOrder.Content.ReadAsStreamAsync();
            }

            return Page();
        }
    }
}