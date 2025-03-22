using CoinsApplication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoinsApplication.Services
{
    public class CoinService
    {
        private readonly HttpClient _httpClient;
        private const string _BaseUrl = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

        public CoinService()
        {
            var config = ConfigService.LoadConfiguration();
            var apiKey = config["ApiSettings:ApiKey"]; // Отримуємо ключ
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", apiKey);
        }

        public async Task<List<CoinCurrency>> GetCryptosAsync(int limit)
        {
            try
            {
                var url = $"{_BaseUrl}?limit={limit}&convert=USD";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Request error: {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var cryptoData = JsonSerializer.Deserialize<CoinApiResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return cryptoData?.Data ?? new List<CoinCurrency>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                return new List<CoinCurrency>();
            }
        }
        public async Task<CoinCurrency> GetCryptoByIdAsync(int coinId)
        {
            try
            {
                var url = $"{_BaseUrl}?id={coinId}&convert=USD";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Request error: {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var cryptoData = JsonSerializer.Deserialize<CoinApiResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return cryptoData?.Data?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                return null;
            }
        }




    }
}