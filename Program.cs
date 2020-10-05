using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlphaVantage.Net.Common.Intervals;
using AlphaVantage.Net.Common.Size;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.Client;

namespace alphavantage_dotnet_example
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractData();
        }

        private static async void ExtractData()
        {
            // use your AlphaVantage API key
            string apiKey = "1";
            // there are 5 more constructors available
            using var client = new AlphaVantageClient(apiKey);
            using var stocksClient = client.Stocks();

            var stocks = new string[] { "AMZN", "STNE", "CQQQ", "VNQ", "BRK-B", "GOOG", "SPY", "QQQ", "AAPL", "EWY", "VNQI", "EWJ", "MSFT", "MELI", "CZZ", "GOOGL", "DIS" };

            foreach (var stock in stocks)
            {
                StockTimeSeries stockTs = stocksClient.GetTimeSeriesAsync(stock, Interval.Daily, OutputSize.Compact, isAdjusted: false).Result;

                foreach (var s in stockTs.DataPoints)
                {
                    Console.WriteLine($"Symbol: {stock}, Data: {s.Time.ToShortDateString()}, Value: {s.ClosingPrice:n2}");
                }
            }
        }
    }
}
