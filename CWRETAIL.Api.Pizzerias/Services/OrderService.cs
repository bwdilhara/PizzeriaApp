using CWRETAIL.Api.Pizzerias.Interfaces;
using CWRETAIL.Api.Pizzerias.Models;
using System.Text;
using System.Text.Json;

namespace CWRETAIL.Api.Pizzerias.Services
{
    public class OrderService:IOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IHttpClientFactory httpClientFactory, ILogger<OrderService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool isSuccess,decimal totalAmount , string errorMessage)> CreateOrderAsync(Order order)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("OrderService");               
                var request = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"api/orders", request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<decimal>(content, options);
                    return (true, result, null);
                }
                return (false, 0, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, 0, ex.Message);
            }
        }

    }
}
