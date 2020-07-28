using FinanceHub.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceHub.Services
{
    public interface IWatchlistService
    {
        Task<bool> AddEntryInWatchListAsync(string symbol);

        IEnumerable<string> GetWatchList();

        bool RemoveEntryInWatchList(string symbol);
    }
}
