using CarteiraDeInvestimentos.Entities;
using CarteiraDeInvestimentos.Entities.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Informe a criptomoeda: ");
        Console.WriteLine("Bitcoin -> BTC");
        Console.WriteLine("Ethereum -> ETH");
        Console.WriteLine("Litecoin -> LTC");
        Console.WriteLine("Ripple -> XRP");
        string coin = Console.ReadLine();
        Console.WriteLine(" ");

        Console.WriteLine("Informe o serviço: ");
        Console.WriteLine("1 - ticker : resumo de operações executadas");
        Console.WriteLine("2 - trades : histórico de operações executadas");
        Console.WriteLine("3 - orderbook : livro de negociações, ordens abertas de compra e venda");
        string method = Console.ReadLine();
        Console.WriteLine(" ");

        AllServices allServices = new AllServices();
        BaseEntity result = await allServices.Integracao(coin, method);

        if (result.Verificacao)
        {
            Console.WriteLine($"Não foi possível encontrar o método {method}");
        }
        else if (result is Ticker ticker)
        {
            Console.WriteLine($"Informações do {coin} - Resumo de operações: ");
            Console.WriteLine($"High: {ticker.High}");
            Console.WriteLine($"Low: {ticker.Low}");
            Console.WriteLine($"Vol: {ticker.Vol}");
            Console.WriteLine($"Last: {ticker.Last}");
            Console.WriteLine($"Buy: {ticker.Buy}");
            Console.WriteLine($"Sell: {ticker.Sell}");
            Console.WriteLine($"Open: {ticker.Open}");
            Console.WriteLine($"Date: {DateTimeOffset.FromUnixTimeSeconds(ticker.Date).DateTime}");
        }
        else if (result is TradesResponse tradesResponse)
        {
            Console.WriteLine($"Informações do {coin} - Histórico de operações executadas: ");
            foreach (var trade in tradesResponse.TradesList)
            {
                Console.WriteLine($"Amount: {trade.Amount}");
                Console.WriteLine($"Date: {trade.Date}");
                Console.WriteLine($"Price: {trade.Price}");
                Console.WriteLine($"Tid: {trade.Tid}");
                Console.WriteLine($"Type: {trade.Type}");
                Console.WriteLine(" ");
            }
        }
    }
}