using CWRETAIL.Api.Pizzerias.Interfaces;
using CWRETAIL.Api.Pizzerias.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;

namespace CWRETAIL.Api.Pizzerias.Services
{
    public class MenuService: IMenuService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<MenuService> _logger;

        public MenuService(IHttpClientFactory httpClientFactory, ILogger<MenuService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool isSuccess, IEnumerable<LocationMenu> menus, string errorMessage)> GetMenuAsync(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("MenuService");
                var response = await client.GetAsync($"api/menus/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<LocationMenu>>(content, options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
