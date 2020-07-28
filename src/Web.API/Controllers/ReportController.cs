using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreeFourteen.Finnhub.Client.Model;

namespace FinanceHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        //private IDatasourceManager datasourceManager = new DatasourceManager("bsfi3ofrh5rf14r5p3tg");
        private IDatasourceManager _datasourceManager;

        public ReportController(IDatasourceManager datasourceManager)
        {
            _datasourceManager = datasourceManager;
        }


        // GET api/Report/Msft
        [HttpGet("/quote/{symbol}")]
        public async Task<ActionResult<Quote>> GetQuote(string symbol)
        {
            return await _datasourceManager.GetQuoteAsync(symbol).ConfigureAwait(false);
        }
    }
}