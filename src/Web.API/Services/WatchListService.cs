using FinanceHub.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ThreeFourteen.Finnhub.Client;
using ThreeFourteen.Finnhub.Client.Model;

namespace FinanceHub.Models
{
    public class WatchlistService : IWatchlistService
    {

        private IDictionary<string, WatchlistEntry> _watchlistDict;
        private FinnhubClient _finnhubClient;

        public WatchlistService()
        {
            // TODO: move this to configuration
            var finnhubAPIKey = "<FinnHub API Key here>";

            // TODO: add persistant storage handler to store the data in database
            this._watchlistDict = new Dictionary<string, WatchlistEntry>();
            this._finnhubClient = new FinnhubClient(finnhubAPIKey);
        }

        public async Task<bool> AddEntryInWatchListAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            try
            {
                Quote currentQuote = await this.GetCurrentQuoteAsync(symbol).ConfigureAwait(false);
                var change = currentQuote.Current - currentQuote.Open;
                var percentChange = (change * 100) / (currentQuote.Open);

                var newWatchListEntry = new WatchlistEntry()
                {
                    Symbol = symbol,
                    CurrentQuote = currentQuote,
                    Change = change,
                    PercentChange = percentChange,
                    UpdatedTime = DateTime.Now
                };

                return this._watchlistDict.TryAdd(symbol, newWatchListEntry);
            }
            catch(Exception)
            {
                return false;
            }
        }
        
        public IEnumerable<string> GetWatchList()
        {
            return this._watchlistDict.Keys;
        }

        public bool RemoveEntryInWatchList(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));
            if (!this._watchlistDict.Keys.Contains(symbol)) throw new ArgumentOutOfRangeException("Symbol does not exist");

            return this._watchlistDict.Remove(symbol);
        }

        private async Task<Quote> GetCurrentQuoteAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException(nameof(symbol));

            return await this._finnhubClient.Stock.GetQuote(symbol).ConfigureAwait(false);
        }
    }
}
