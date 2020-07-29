using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.TimeSeries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client;
using ThreeFourteen.Finnhub.Client.Model;
using Newtonsoft.Json;

namespace FinanceHub
{
    public class DatasourceManager : IDatasourceManager
    {
        private readonly FinnhubClient finnhubClient;
        private readonly AlphaVantageStocksClient _alphaClient;
        // TODO: Add correct key here.
        private string finhubbApiKey = "abc";
        private string alphavantagekey = "demo";

        public DatasourceManager()
        {
           finnhubClient = new FinnhubClient(finhubbApiKey);
           _alphaClient = new AlphaVantageStocksClient(alphavantagekey);
        }


        public async Task<Quote> GetQuoteAsync(string symbol)
        {
           return await this.finnhubClient.Stock.GetQuote(symbol);
            
        }

        public async Task<string> GetTimeSeriesDaily(string symbol)
        {

            StockTimeSeries st = await _alphaClient.RequestDailyTimeSeriesAsync(symbol, TimeSeriesSize.Compact, adjusted: false);
            return st.ToString();
        }
    }
}
