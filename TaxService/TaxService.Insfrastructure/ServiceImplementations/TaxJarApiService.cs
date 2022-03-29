using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using TaxService.Application.DTOs;
using TaxService.Application.Interfaces;
using TaxService.Core.Models;

namespace TaxService.Insfrastructure
{
    public class TaxJarApiService : IRepository
    {
        private readonly HttpClient _client;
        public TaxJarApiService(IConfiguration configuration)
        {
            var key = configuration["TaxJar:Key"];
            _client = new HttpClient();
            var url = configuration["TaxJar:BaseUrl"];
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Add("User-Agent", "Tax Service");
            _client.DefaultRequestHeaders.Add("Authorization",$"Token token={key}");
        }

        public async Task<TaxResponse> CalculateTaxByOrderAsync(OrderDTO orderDto)
        {
            var endpoint = $"taxes";

            var body = JsonConvert.SerializeObject(orderDto);
            if (string.IsNullOrWhiteSpace(body))
                throw new JsonSerializationException("Could not serialize order");
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            var taxDto = JsonConvert.DeserializeObject<TaxResponse>(result ?? "{}");
            return taxDto;
        }

        public async Task<RateResponse> GetRateByLocationAsync(Location location)
        {
            var endpoint = $"rates/{location.Zip}?";

            var queryStr = string.Empty;
            if (!string.IsNullOrWhiteSpace(location.Country))
                queryStr += $"&country={location.Country}";

            if (!string.IsNullOrWhiteSpace(location.State))
                queryStr += $"&state={location.State}";

            if (!string.IsNullOrWhiteSpace(location.City))
                queryStr += $"&city={location.City}";

            if (!string.IsNullOrWhiteSpace(location.Street))
                queryStr += $"&street={location.Street}";

            if (queryStr.StartsWith("&"))
                queryStr = queryStr.Substring(1);

            endpoint += Uri.EscapeDataString(queryStr);
            var response = await _client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            var rateDto = JsonConvert.DeserializeObject<RateResponse>(result ?? "{}");
            return rateDto;
        }
    }
}