using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.Finnhub.Client.Model;

namespace FinanceHub
{
    public interface IDatasourceManager
    {
       Task<Quote> GetQuoteAsync(string symbol);
    }
}
