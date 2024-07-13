using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CarteiraDeInvestimentos.Entities.Services
{
    internal class AllServices
    {
        public async Task<BaseEntity> Integracao(string coin, string method)
        {
            using HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://www.mercadobitcoin.net/api/{coin}/{method}/");
            var jsonString = await response.Content.ReadAsStringAsync();

            if (method == "ticker")
            {
                var jsonObject = JsonConvert.DeserializeObject<TickerResponse>(jsonString);
                if (jsonObject?.Ticker != null)
                {
                    return jsonObject.Ticker;
                }
            }
            else if (method == "trades")
            {
                var tradesList = JsonConvert.DeserializeObject<List<Trades>>(jsonString);
                if (tradesList != null)
                {
                    return new TradesResponse { TradesList = tradesList };
                }
            }

            return new BaseEntity { Verificacao = true };
  
        }
    }

    internal class TickerResponse
    {
        [JsonProperty("ticker")]
        public Ticker Ticker { get; set; }
    }

    internal class TradesResponse : BaseEntity
    {
        public List<Trades> TradesList { get; set; }
    }
}