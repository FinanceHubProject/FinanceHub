using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client;
using ThreeFourteen.Finnhub.Client.Model;

namespace FinanceHub
{
    public class DatasourceManager : IDatasourceManager
    {
        private readonly FinnhubClient finnhubClient;
        // TODO: Add correct key here.
        private string finhubbApiKey = "abc";

        public DatasourceManager()
        {
           finnhubClient = new FinnhubClient(finhubbApiKey);
        }


        public async Task<Quote> GetQuoteAsync(string symbol)
        {
           return await this.finnhubClient.Stock.GetQuote(symbol);
            
        }

    }
}
