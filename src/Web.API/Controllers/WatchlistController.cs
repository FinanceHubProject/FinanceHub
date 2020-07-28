using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinanceHub.Models;
using FinanceHub.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;

namespace FinanceHub.Controllers
{
    [Route("api/Watchlist")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private IWatchlistService _watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }

        [Route("Stock")]
        [HttpPost]
        public async Task<ActionResult<bool>> AddStockInWatchlistAsync(string symbol)
        {
            // TODO: add error handling and appropriate http return codes
            return await _watchlistService.AddEntryInWatchListAsync(symbol).ConfigureAwait(false);
        }

        [Route("Stock")]
        [HttpDelete]
        public ActionResult<bool> RemoveStockFromWatchlist(string symbol)
        {
            return _watchlistService.RemoveEntryInWatchList(symbol);
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetWatchList()
        {
            return _watchlistService.GetWatchList().ToList();
        }
    }
}
