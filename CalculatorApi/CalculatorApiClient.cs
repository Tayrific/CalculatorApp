using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class CalculatorApiClient : ICalculatorAsync
    {
        private readonly HttpClient _httpClient;

        public CalculatorApiClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:<port>/api/calculator/") }; 
        }

        public async Task<int> AddAsync(int start, int amount)
        {
            var response = await _httpClient.GetAsync($"add?start={start}&amount={amount}");
            response.EnsureSuccessStatusCode();
            return int.Parse(await response.Content.ReadAsStringAsync());
        }

        public async Task<int> SubtractAsync(int start, int amount)
        {
            var response = await _httpClient.GetAsync($"subtract?start={start}&amount={amount}");
            response.EnsureSuccessStatusCode();
            return int.Parse(await response.Content.ReadAsStringAsync());
        }

        public async Task<int> MultiplyAsync(int start, int by)
        {
            var response = await _httpClient.GetAsync($"multiply?start={start}&by={by}");
            response.EnsureSuccessStatusCode();
            return int.Parse(await response.Content.ReadAsStringAsync());
        }

        public async Task<int> DivideAsync(int start, int by)
        {
            var response = await _httpClient.GetAsync($"divide?start={start}&by={by}");
            response.EnsureSuccessStatusCode();
            return int.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}
