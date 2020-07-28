using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ThreeFourteen.Finnhub.Client.Model;

namespace FinanceHub.Models
{
    public class WatchlistEntry
    {
        public string Symbol { get; set; }

        public string CompanyName { get; set; }

        public Quote CurrentQuote { get; set; }

        public DateTime UpdatedTime { get; set; }

        public decimal Change { get; set; }

        public decimal PercentChange { get; set; }
    }
}
