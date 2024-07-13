using Newtonsoft.Json;

namespace CarteiraDeInvestimentos.Entities
{
    internal class BaseEntity
    {
        public bool Verificacao { get; set; }
    }

    internal class Ticker : BaseEntity
    {
        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("vol")]
        public string Vol { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("buy")]
        public string Buy { get; set; }

        [JsonProperty("sell")]
        public string Sell { get; set; }

        [JsonProperty("open")]
        public string Open { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }
    }

    internal class Trades : BaseEntity
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("tid")]
        public string Tid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}