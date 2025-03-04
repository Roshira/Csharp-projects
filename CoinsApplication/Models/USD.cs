using System.Text.Json.Serialization;

namespace CoinsApplication.Models
{
    public class USD
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("percent_change_1h")]
        public decimal PercentChange1h { get; set; }

        [JsonPropertyName("percent_change_24h")]
        public decimal PercentChange24h { get; set; }

        [JsonPropertyName("percent_change_7d")]
        public decimal PercentChange7d { get; set; }
    }
}