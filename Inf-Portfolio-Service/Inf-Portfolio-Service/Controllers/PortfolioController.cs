using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inf_Portfolio_Service.Models;
using Inf_Portfolio_Service.Services;
using Microsoft.AspNetCore.Mvc;


namespace Inf_Portfolio_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        // GET: /api/portfolio/GetOk
        [HttpGet("GetOk")]
        public string GetOk()
        {
            return "all okay";
        }


        #region Portfolio
        // GET: /api/portfolio/GetPortfolios
        [HttpGet("GetPortfolios")]
        public List<Portfolio> GetPortfolios() // quite the antipattern here to return the model directly from the db, a viewmodel could have been used instead, but for the sake of brevity i've went with the model for this demo
        {
            var portService = new PortfolioService();

            return portService.GetAllPortfolios();
        }

        // GET: /api/portfolio/GetPortfolioById/5
        [HttpGet("GetPortfolioById/{id}")]
        public Portfolio GetPortfolioById(int id)
        {
            var portService = new PortfolioService();

            return portService.GetPortfolioById(id);
        }

        // POST: /api/portfolio/CreatePortfolio
        [HttpPost("CreatePortfolio")]
        public bool CreatePortfolio([FromBody] string request)
        {
            var portService = new PortfolioService();

            return portService.CreatePortfolio(request);
        }

        // PUT: /api/portfolio/UpdatePortfolio
        [HttpPut("UpdatePortfolio")]
        public bool UpdatePortfolio([FromBody] string request)
        {
            var portService = new PortfolioService();

            return portService.UpdatePortfolio(request);
        }
        #endregion

        #region Stock
        // POST: /api/portfolio/CreateStock
        [HttpPost("CreateStock")]
        public bool CreateStock([FromBody] string request)
        {
            var stockService = new StockService();

            return stockService.StockCrudOperations(request, Ops.Create);
        }

        // PUT: /api/portfolio/UpdateStock
        [HttpPut("UpdateStock")]
        public bool UpdateStock([FromBody] string request)
        {
            var stockService = new StockService();

            return stockService.StockCrudOperations(request, Ops.Update);
        }

        // DELETE: /api/portfolio/DeleteStock
        [HttpDelete("DeleteStock")]
        public bool DeleteStock([FromBody] string request)
        {
            var stockService = new StockService();

            return stockService.StockCrudOperations(request, Ops.Delete);
        }
        #endregion
    }
}
